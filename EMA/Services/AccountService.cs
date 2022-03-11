using EMA.Data;
using EMA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface IAccountService
    {
        Task<string> Login(LoginModel data);
        Task<bool> Register(RegisterModel data);
        dynamic GetAllUser(int take);
        bool ChangeUserStatus(string Id);
        ExcelDownloadModel DownloadSurway();
    }
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signIn;
        private readonly IConfiguration _config;
        public AccountService(IConfiguration config,ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
        {
            _context = context;
            _userManager = userManager;
            _signIn = signIn;
            _config = config;
        }

        public dynamic GetAllUser(int take)
        {
            bool moreExist = false;

            string roleId = _context.Roles.Where(x => x.Name == "admin").FirstOrDefault().Id;
            string adminId = _context.UserRoles.Where(x => x.RoleId == roleId).FirstOrDefault().UserId;
            var list = _context.Users.Select(x => new { Id = x.Id, UserName = x.UserName.Replace("_", " "), Status = x.EmailConfirmed }).Where(x => x.Id != adminId).AsQueryable();
            int total = list.Count() - (take - 1) * 2;
            if (total > 2)
                moreExist = true;
            else
                moreExist = false;
            return new { take = take, exist = moreExist, list = list.Skip((take - 1) * 2).Take(2).ToList() };

        }

        public bool ChangeUserStatus(string Id)
        {
            var _doesExist = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (_doesExist != null)
            {
                _doesExist.EmailConfirmed = _doesExist.EmailConfirmed ?  false : true;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public async Task<string> Login(LoginModel data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            if (!user.EmailConfirmed)
            {
                throw new Exception("Account is Deactivate");
            }

            var result = await _signIn.CheckPasswordSignInAsync(user, data.Password,false);


            if (!result.Succeeded)
            {
                throw new Exception("Invalid login attempt.");
            }


            var role = await _userManager.GetRolesAsync(user);

            string token =  GenerateJSONWebToken(role.FirstOrDefault(),user.Id);
            return token;
        }
        public async Task<bool> Register(RegisterModel data)
        {
            var existingUser = await _userManager.FindByEmailAsync(data.Email);
            if (existingUser != null)
            {
                throw new Exception("Email address already exists.");
            }
            if (data.Password != data.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match");
            }
            IdentityUser user = new IdentityUser();
            user.UserName = data.FullName.Replace(" ","_");
            user.Email = data.Email;
            user.LockoutEnabled = false;
            user.EmailConfirmed = false;

            var result = await _userManager.CreateAsync(user, data.Password);
            if (!result.Succeeded)
                throw new Exception(result.Errors.FirstOrDefault().Description);
             await _userManager.AddToRoleAsync(user, "surwayer");

            
            return true;
        }

        public ExcelDownloadModel DownloadSurway()
        {
            ExcelDownloadModel downloadModel = new ExcelDownloadModel();
            downloadModel.SeedBeed = _context.SeedBeed.Include(x => x.FarmerDetail).Include(x => x.Machine)
                                        .Include(x => x.Equipment).Select(x => new SeedBeedDownloadMode
                                        {
                                            FarmerName = x.FarmerDetail.FullName,
                                            TypeOperation = x.TypeOperation,
                                            DieselLPH = x.DieselLPH,
                                            DirectEnergyMJPH = x.DirectEnergyMJPH,
                                            DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                            DriverLabour   = x.DriverLabour,
                                            Equipment = x.Equipment.Name,
                                            FuelEnergy = x.FuelEnergy,
                                            HumanEnergy = x.HumanEnergy,
                                            InDirectEnergyMJPH = x.InDirectEnergyMJPH,
                                            InDirectEnergyMJPHa = x.InDirectEnergyMJPHa,
                                            Machine = x.Machine.Name,
                                            NoOfPass = x.NoOfPass,
                                            OperationalEnergy = x.OperationalEnergy,
                                            OwnHired = x.OwnHired,
                                            Rate = x.Rate,
                                            TotalDirectEnergyMJPHa = x.TotalDirectEnergyMJPHa,
                                            TotalInDirectEnergyMJPHa = x.TotalInDirectEnergyMJPHa
                                        }).ToList();

            downloadModel.Sowing = _context.Sowing.Include(x => x.FarmerDetail).Include(x => x.Machine)
                                       .Include(x => x.Equipment).Select(x => new SowingDownloadMode
                                       {
                                           Farmer = x.FarmerDetail.FullName,
                                           DieselLPH = x.DieselLPH,
                                           DirectEnergyMJPH = x.DirectEnergyMJPH,
                                           DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                           DriverLabour = x.DriverLabour,
                                           Equipment = x.Equipment.Name,
                                           FuelEnergy = x.FuelEnergy,
                                           HumanEnergy = x.HumanEnergy,
                                           InDirectEnergyMJPHa = x.InDirectEnergyMJPHa,
                                           Machine = x.Machine.Name,
                                           NoOfPass = x.NoOfPass,
                                           OperationalEnergy = x.OperationalEnergy,
                                           OwnHired = x.OwnHired,
                                           Rate = x.Rate,
                                           TotalDirectEnergyMJPHa = x.TotalDirectEnergyMJPHa,
                                           Material = x.Material,
                                           QtyKgPHa = x.QtyKgPHa
                                       }).ToList();

            downloadModel.Fertilizer = _context.Fertilizer.Include(x => x.FarmerDetail)
                                       .Select(x => new FertilizerDownloadMode
                                       {
                                           Farmer = x.FarmerDetail.FullName,
                                           DirectEnergyMJPH = x.DirectEnergyMJPH,
                                           DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                           HumanEnergy = x.HumanEnergy,
                                           InDirectEnergyMJPHa = x.InDirectEnergyMJPHa,
                                           NoOfPass = x.NoOfPass,
                                           OperationalEnergy = x.OperationalEnergy,
                                           TotalDirectEnergyMJPHa = x.TotalDirectEnergyMJPHa,
                                           Capacity = x.Capacity,
                                           Labourer = x.Labourer,
                                           Material1 = x.Material1,
                                           Material2 = x.Material2,
                                           Material3 = x.Material3,
                                           Material4 = x.Material4,
                                           QtyKgPHa1 = x.QtyKgPHa1,
                                           QtyKgPHa2 = x.QtyKgPHa2,
                                           QtyKgPHa3 = x.QtyKgPHa3,
                                           QtyKgPHa4 = x.QtyKgPHa4,
                                           TotalEnergy = x.TotalEnergy
                                       }).ToList();

            downloadModel.PlantProtection = _context.PlantProtection.Include(x => x.FarmerDetail).Include(x => x.Machine)
                                       .Include(x => x.Equipment).Select(x => new PlantProtectionDownloadMode
                                       {
                                           Farmer = x.FarmerDetail.FullName,
                                           DieselLPH = x.DieselLPH,
                                           DirectEnergyMJPH = x.DirectEnergyMJPH,
                                           DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                           DriverLabour = x.DriverLabour,
                                           Equipment = x.Equipment.Name,
                                           FuelEnergy = x.FuelEnergy,
                                           HumanEnergy = x.HumanEnergy,
                                           InDirectEnergyMJPHa = x.InDirectEnergyMJPHa,
                                           Machine = x.Machine.Name,
                                           NoOfPass = x.NoOfPass,
                                           OperationalEnergy = x.OperationalEnergy,
                                           OwnHired = x.OwnHired,
                                           Rate = x.Rate,
                                           TotalDirectEnergyMJPHa = x.TotalDirectEnergyMJPHa,
                                           Material = x.Material,
                                           QtyKgPHa = x.QtyKgPHa
                                       }).ToList();

            downloadModel.InterCulture = _context.InterCulture.Include(x => x.FarmerDetail).Include(x => x.Machine)
                                       .Include(x => x.Equipment).Select(x => new InterCultureDownloadMode
                                       {
                                           Farmer = x.FarmerDetail.FullName,
                                           DieselLPH = x.DieselLPH,
                                           DirectEnergyMJPH = x.DirectEnergyMJPH,
                                           DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                           DriverLabour = x.DriverLabour,
                                           Equipment = x.Equipment.Name,
                                           FuelEnergy = x.FuelEnergy,
                                           HumanEnergy = x.HumanEnergy,
                                           InDirectEnergyMJPHa = x.InDirectEnergyMJPHa,
                                           Machine = x.Machine.Name,
                                           NoOfPass = x.NoOfPass,
                                           OperationalEnergy = x.OperationalEnergy,
                                           OwnHired = x.OwnHired,
                                           Rate = x.Rate,
                                           TotalDirectEnergyMJPHa = x.TotalDirectEnergyMJPHa,
                                           Material = x.Material,
                                           QtyKgPHa = x.QtyKgPHa
                                       }).ToList();
            downloadModel.Irrigation = _context.Irrigation.Include(x => x.FarmerDetail).Include(x => x.Machine)
                                       .Include(x => x.Equipment).Select(x => new IrrigationDownloadMode
                                       {
                                           Farmer = x.FarmerDetail.FullName,
                                           EleckWh = x.EleckWh,
                                           DirectEnergyMJPH = x.DirectEnergyMJPH,
                                           DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                           ElecEnergy = x.ElecEnergy,
                                           Equipment = x.Equipment.Name,
                                           HumanEnergy = x.HumanEnergy,
                                           InDirectEnergyMJPHa = x.InDirectEnergyMJPHa,
                                           Machine = x.Machine.Name,
                                           NoOfPass = x.NoOfPass,
                                           OperationalEnergy = x.OperationalEnergy,
                                           OwnHired = x.OwnHired,
                                           TotalDirectEnergyMJPHa = x.TotalDirectEnergyMJPHa,
                                           OperatorLabour = x.OperatorLabour,
                                           TimeTaken = x.TimeTaken
                                       }).ToList();

            downloadModel.Harvesting = _context.Harvesting.Include(x => x.FarmerDetail).Include(x => x.Machine)
                                       .Include(x => x.Equipment).Select(x => new HarvestingDownloadMode
                                       {
                                           Farmer = x.FarmerDetail.FullName,
                                           DieselLPH = x.DieselLPH,
                                           DirectEnergyMJPH = x.DirectEnergyMJPH,
                                           DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                           DriverLabour = x.DriverLabour,
                                           Equipment = x.Equipment.Name,
                                           FuelEnergy = x.FuelEnergy,
                                           HumanEnergy = x.HumanEnergy,
                                           InDirectEnergyMJPHa = x.InDirectEnergyMJPHa,
                                           Machine = x.Machine.Name,
                                           NoOfPass = x.NoOfPass,
                                           OperationalEnergy = x.OperationalEnergy,
                                           OwnHired = x.OwnHired,
                                           Rate = x.Rate,
                                           InDirectEnergyMJPH = x.InDirectEnergyMJPH,
                                           LabourChargePDay = x.LabourChargePDay,
                                           TotalEnergy = x.TotalEnergy,
                                           TypeOperation = x.TypeOperation
                                       }).ToList();

            downloadModel.Production = _context.Production.Include(x => x.FarmerDetail)
                                        .Select(x => new ProductionDownloadMode
                                       {
                                            Farmer = x.FarmerDetail.FullName,
                                            GrainProduction = x.GrainProduction,
                                            GrainStrawRatio = x.GrainStrawRatio,
                                            Price = x.Price,
                                            StrawProduction = x.StrawProduction,
                                            TotalEnergyGrainMJPHa = x.TotalEnergyGrainMJPHa,
                                            TotalEnergyMJPHa = x.TotalEnergyMJPHa,
                                            TotalEnergyStrawMJPHa = x.TotalEnergyStrawMJPHa
                                        }).ToList();




                return downloadModel;

        }


        private string GenerateJSONWebToken(string role, string userid)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();
            claims.Add(new Claim("role", role));
            claims.Add(new Claim("userId", userid));
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims.ToArray(),
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
