using EMA.Data;
using EMA.EntityModels;
using EMA.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace EMA.Services
{
    public interface IFarmerService 
    {
        List<FarmerModel> GetData();
        bool AddUpdate(FarmerModel data);
        bool Delete(int Id);
        FarmerDetail GetDataById(int Id);
        ExcelDownloadModel DownloadSurwayDataByFarmerId(int farmerId);
    }
    public class FarmerService : IFarmerService
    {
        readonly ApplicationDbContext _context;
        readonly IConfiguration _config;
        public FarmerService(ApplicationDbContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
       
        public List<FarmerModel> GetData()
        {
            
            var farmerList = (from fd in _context.FarmerDetail
                              join u in _context.Users on fd.CreatedBy equals u.Id
                              select new FarmerModel
                              {
                                  Id = fd.Id,
                                  FullName = fd.FullName,
                                  Address = fd.Address,
                                  LandHolding = fd.LandHolding,
                                  Phone = fd.Phone,
                                  CreatedBy = u.UserName.Replace("_", " "),
                                  CreatedDate = fd.CreatedDateUtc
                              }).ToList();

            return farmerList;

        }
       
        public bool AddUpdate(FarmerModel data)
        {
            FarmerDetail _doesExist = _context.FarmerDetail.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {
                FarmerDetail farmerDetail = new FarmerDetail();
                farmerDetail.FullName = data.FullName;
                farmerDetail.LandHolding = data.LandHolding;
                farmerDetail.Phone = data.Phone;
                farmerDetail.Address = data.Address;
                farmerDetail.CreatedBy = data.CreatedBy;
                _context.FarmerDetail.Add(farmerDetail);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.FullName = data.FullName;
                _doesExist.LandHolding = data.LandHolding;
                _doesExist.Address = data.Address;
                _doesExist.Phone = data.Phone;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            FarmerDetail _doesExist = _context.FarmerDetail.Where(x => x.Id == Id).FirstOrDefault();

            _context.FarmerDetail.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
        public FarmerDetail GetDataById(int Id)
        {
            return _context.FarmerDetail.Where(x => x.Id == Id).FirstOrDefault();
        }

        public ExcelDownloadModel DownloadSurwayDataByFarmerId(int farmerId)
        {
            ExcelDownloadModel downloadModel = new ExcelDownloadModel();
            downloadModel.SeedBeed = _context.SeedBeed.Include(x => x.FarmerDetail).Include(x => x.Machine)
                                        .Include(x => x.Equipment).Where(x => x.Farmerid == farmerId).Select(x => new SeedBeedDownloadMode
                                        {
                                            FarmerName = x.FarmerDetail.FullName,
                                            TypeOperation = x.TypeOperation,
                                            DieselLPH = x.DieselLPH,
                                            DirectEnergyMJPH = x.DirectEnergyMJPH,
                                            DirectEnergyMJPHa = x.DirectEnergyMJPHa,
                                            DriverLabour = x.DriverLabour,
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
                                       .Include(x => x.Equipment).Where(x => x.Farmerid == farmerId).Select(x => new SowingDownloadMode
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

            downloadModel.Fertilizer = _context.Fertilizer.Include(x => x.FarmerDetail).Where(x => x.Farmerid == farmerId)
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
                                       .Include(x => x.Equipment).Where(x => x.Farmerid == farmerId).Select(x => new PlantProtectionDownloadMode
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
                                       .Include(x => x.Equipment).Where(x => x.Farmerid == farmerId).Select(x => new InterCultureDownloadMode
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
                                       .Include(x => x.Equipment).Where(x => x.Farmerid == farmerId).Select(x => new IrrigationDownloadMode
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
                                       .Include(x => x.Equipment).Where(x => x.Farmerid == farmerId).Select(x => new HarvestingDownloadMode
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

            downloadModel.Production = _context.Production.Include(x => x.FarmerDetail).Where(x => x.Farmerid == farmerId)
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

    }
}
