using EMA.Data;
using EMA.EntityModels;
using EMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface IMachineService
    {
        List<Machine> GetData();
        bool AddUpdate(MachineModel data);
        bool Delete(int Id);
    }
    public class MachineService : IMachineService
    {
        readonly ApplicationDbContext _context;
        public MachineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Machine> GetData()
        {
            return _context.Machine.ToList();

        }

        public bool AddUpdate(MachineModel data)
        {
            Machine _doesExist = _context.Machine.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {
                Machine _details = new Machine();
                _details.Name = data.Name;
                _details.BrandName = data.BrandName;
                _details.ModelId = data.ModelId;
                _details.MachineType = data.MachineType;
                _details.HP = data.HP;
                _details.WeightKg = data.WeightKg;
                _details.LifeHr = data.LifeHr;
                _details.Energy = Convert.ToInt32(68.4 * (data.WeightKg / data.LifeHr));
                _details.CreatedBy = "null";
                _context.Machine.Add(_details);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.Name = data.Name;
                _doesExist.BrandName = data.BrandName;
                _doesExist.ModelId = data.ModelId;
                _doesExist.MachineType = data.MachineType;
                _doesExist.HP = data.HP;
                _doesExist.WeightKg = data.WeightKg;
                _doesExist.Energy = Convert.ToInt32(68.4 * (data.WeightKg / data.LifeHr));
                _doesExist.LifeHr = data.LifeHr;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            Machine _doesExist = _context.Machine.Where(x => x.Id == Id).FirstOrDefault();

            _context.Machine.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
