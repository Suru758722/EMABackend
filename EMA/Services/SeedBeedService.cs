using EMA.Data;
using EMA.EntityModels;
using EMA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface ISeedBeedService
    {
        dynamic GetData(int take);
        bool AddUpdate(SeedBeedModel data);
        bool Delete(int Id);
    }
    public class SeedBeedService : ISeedBeedService
    {
        readonly ApplicationDbContext _context;
        public SeedBeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public dynamic GetData(int take)
        {
            var list =  _context.SeedBeed.Include(x => x.Machine).Include(x => x.Equipment).Include(x => x.FarmerDetail).ThenInclude(x => x.Crop).AsQueryable();
            bool moreExist = false;
            int total = list.Count() - (take - 1) * 2;
            if (total > 2)
                moreExist = true;
            else
                moreExist = false;
            return new { take = take, exist = moreExist, list = list.Skip((take - 1) * 2).Take(2).ToList() };

        }
        public bool AddUpdate(SeedBeedModel data)
        {
            Equipment equipment = _context.Equipment.Where(x => x.Id == data.EquipmentId).FirstOrDefault();
            double _machineEnergy = _context.Machine.Where(x => x.Id == data.MachineId).FirstOrDefault().Energy;
            SeedBeed _doesExist = _context.SeedBeed.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {
               
                SeedBeed _detail = new SeedBeed();
                _detail.TypeOperation = data.TypeOperation;
                _detail.Farmerid = data.FarmerId;
                _detail.MachineId = data.MachineId;
                _detail.EquipmentId = data.EquipmentId;
                _detail.OwnHired = data.OwnHired;
                _detail.Rate = data.Rate;
                _detail.DieselLPH = data.DieselLPH;
                _detail.FuelEnergy = 56.31 * data.DieselLPH;
                _detail.DriverLabour = data.DriverLabour;
                _detail.HumanEnergy = 1.96 * data.DriverLabour;
                _detail.DirectEnergyMJPH = _detail.HumanEnergy + _detail.FuelEnergy;
                _detail.DirectEnergyMJPHa = _detail.DirectEnergyMJPH*(1/ equipment.Capacity);
                _detail.NoOfPass = data.NoOfPass;
                _detail.InDirectEnergyMJPH = _machineEnergy + equipment.Energy;
                _detail.InDirectEnergyMJPHa = _detail.InDirectEnergyMJPH * (1/ equipment.Capacity);
                _detail.TotalDirectEnergyMJPHa = _detail.DirectEnergyMJPHa * data.NoOfPass;
                _detail.TotalInDirectEnergyMJPHa = _detail.InDirectEnergyMJPHa * data.NoOfPass;
                _detail.OperationalEnergy = (_detail.DirectEnergyMJPHa + _detail.InDirectEnergyMJPHa) * data.NoOfPass;
                _context.SeedBeed.Add(_detail);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.Farmerid = data.FarmerId;
                _doesExist.MachineId = data.MachineId;
                _doesExist.EquipmentId = data.EquipmentId;
                _doesExist.TypeOperation = data.TypeOperation;
                _doesExist.OwnHired = data.OwnHired;
                _doesExist.Rate = data.Rate;
                _doesExist.DieselLPH = data.DieselLPH;
                _doesExist.FuelEnergy = 56.31 * data.DieselLPH;
                _doesExist.DriverLabour = data.DriverLabour;
                _doesExist.HumanEnergy = 1.96 * data.DriverLabour;
                _doesExist.DirectEnergyMJPH = _doesExist.HumanEnergy + _doesExist.FuelEnergy;
                _doesExist.DirectEnergyMJPHa = _doesExist.DirectEnergyMJPH * (1 / equipment.Capacity);
                _doesExist.NoOfPass = data.NoOfPass;
                _doesExist.InDirectEnergyMJPH = _machineEnergy + equipment.Energy;
                _doesExist.InDirectEnergyMJPHa = _doesExist.InDirectEnergyMJPH * (1 / equipment.Capacity);
                _doesExist.TotalDirectEnergyMJPHa = _doesExist.DirectEnergyMJPHa * data.NoOfPass;
                _doesExist.TotalInDirectEnergyMJPHa = _doesExist.InDirectEnergyMJPHa * data.NoOfPass;
                _doesExist.OperationalEnergy = (_doesExist.DirectEnergyMJPHa + _doesExist.InDirectEnergyMJPHa) * data.NoOfPass;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            SeedBeed _doesExist = _context.SeedBeed.Where(x => x.Id == Id).FirstOrDefault();

            _context.SeedBeed.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
