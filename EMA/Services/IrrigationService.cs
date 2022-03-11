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
    public interface IIrrigationService
    {
        dynamic GetData(int take);
        bool AddUpdate(IrrigationModel data);
        bool Delete(int Id);
    }
    public class IrrigationService : IIrrigationService
    {
        readonly ApplicationDbContext _context;
        public IrrigationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public dynamic GetData(int take)
        {
            var list =  _context.Irrigation.Include(x => x.Machine).Include(x => x.Equipment).Include(x => x.FarmerDetail).ThenInclude(x => x.Crop).AsQueryable();
            bool moreExist = false;
            int total = list.Count() - (take - 1) * 2;
            if (total > 2)
                moreExist = true;
            else
                moreExist = false;
            return new { take = take, exist = moreExist, list = list.Skip((take - 1) * 2).Take(2).ToList() };

        }
        public bool AddUpdate(IrrigationModel data)
        {
            double _machineEnergy = _context.Machine.Where(x => x.Id == data.MachineId).FirstOrDefault().Energy;
            Irrigation _doesExist = _context.Irrigation.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {

                Irrigation _detail = new Irrigation();
                _detail.Farmerid = data.FarmerId;
                _detail.MachineId = data.MachineId;
                _detail.EquipmentId = data.EquipmentId;
                _detail.OwnHired = data.OwnHired;
                _detail.EleckWh = data.EleckWh;
                _detail.ElecEnergy = 11.93 * data.EleckWh;
                _detail.TimeTaken = data.TimeTaken;
                _detail.OperatorLabour = data.DriverLabour;
                _detail.HumanEnergy = 1.96 * data.DriverLabour;
                _detail.DirectEnergyMJPH = _detail.HumanEnergy + _detail.ElecEnergy;
                _detail.DirectEnergyMJPHa = _detail.DirectEnergyMJPH * data.TimeTaken;
                _detail.NoOfPass = data.NoOfPass;
                _detail.InDirectEnergyMJPHa = _machineEnergy * data.NoOfPass;
                _detail.TotalDirectEnergyMJPHa = _detail.DirectEnergyMJPHa * data.NoOfPass;
                _detail.OperationalEnergy = _detail.TotalDirectEnergyMJPHa;
                _context.Irrigation.Add(_detail);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.Farmerid = data.FarmerId;
                _doesExist.MachineId = data.MachineId;
                _doesExist.EquipmentId = data.EquipmentId;
                _doesExist.OwnHired = data.OwnHired;
                _doesExist.EleckWh = data.EleckWh;
                _doesExist.ElecEnergy = 11.93 * data.EleckWh;
                _doesExist.TimeTaken = data.TimeTaken;
                _doesExist.OperatorLabour = data.DriverLabour;
                _doesExist.HumanEnergy = 1.96 * data.DriverLabour;
                _doesExist.DirectEnergyMJPH = _doesExist.HumanEnergy + _doesExist.ElecEnergy;
                _doesExist.DirectEnergyMJPHa = _doesExist.DirectEnergyMJPH * data.TimeTaken;
                _doesExist.NoOfPass = data.NoOfPass;
                _doesExist.InDirectEnergyMJPHa = _machineEnergy * data.NoOfPass;
                _doesExist.TotalDirectEnergyMJPHa = _doesExist.DirectEnergyMJPHa * data.NoOfPass;
                _doesExist.OperationalEnergy = _doesExist.TotalDirectEnergyMJPHa;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            Irrigation _doesExist = _context.Irrigation.Where(x => x.Id == Id).FirstOrDefault();

            _context.Irrigation.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
