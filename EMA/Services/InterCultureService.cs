using EMA.Data;
using EMA.EntityModels;
using EMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface IInterCultureService
    {
        List<InterCulture> GetData();
        bool AddUpdate(InterCultureModel data);
        bool Delete(int Id);
    }
    public class InterCultureService : IInterCultureService
    {
        readonly ApplicationDbContext _context;
        public InterCultureService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<InterCulture> GetData()
        {
            return _context.InterCulture.ToList();
        }
        public bool AddUpdate(InterCultureModel data)
        {
            Equipment equipment = _context.Equipment.Where(x => x.Id == data.EquipmentId).FirstOrDefault();
            double _machineEnergy = _context.Machine.Where(x => x.Id == data.MachineId).FirstOrDefault().Energy;
            InterCulture _doesExist = _context.InterCulture.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {

                InterCulture _detail = new InterCulture();
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
                _detail.DirectEnergyMJPHa = _detail.DirectEnergyMJPH * (1 / equipment.Capacity);
                _detail.NoOfPass = data.NoOfPass;
                _detail.Material = data.Material;
                _detail.QtyKgPHa = (double)data.Qty;
                _detail.TotalDirectEnergyMJPHa = _detail.DirectEnergyMJPHa * data.NoOfPass;
                _detail.InDirectEnergyMJPHa = (14.7 * (double)data.Qty) + (_machineEnergy + equipment.Energy);
                _detail.OperationalEnergy = (_detail.TotalDirectEnergyMJPHa + _detail.InDirectEnergyMJPHa);

                _context.InterCulture.Add(_detail);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.Farmerid = data.FarmerId;
                _doesExist.MachineId = data.MachineId;
                _doesExist.EquipmentId = data.EquipmentId;
                _doesExist.OwnHired = data.OwnHired;
                _doesExist.Rate = data.Rate;
                _doesExist.DieselLPH = data.DieselLPH;
                _doesExist.FuelEnergy = 56.31 * data.DieselLPH;
                _doesExist.DriverLabour = data.DriverLabour;
                _doesExist.HumanEnergy = 1.96 * data.DriverLabour;
                _doesExist.DirectEnergyMJPH = _doesExist.HumanEnergy + _doesExist.FuelEnergy;
                _doesExist.DirectEnergyMJPHa = _doesExist.DirectEnergyMJPH * (1 / equipment.Capacity);
                _doesExist.NoOfPass = data.NoOfPass;
                _doesExist.Material = data.Material;
                _doesExist.QtyKgPHa = (double)data.Qty;
                _doesExist.TotalDirectEnergyMJPHa = _doesExist.DirectEnergyMJPHa * data.NoOfPass;
                _doesExist.InDirectEnergyMJPHa = (14.7 * (double)data.Qty) + (_machineEnergy + equipment.Energy);
                _doesExist.OperationalEnergy = (_doesExist.TotalDirectEnergyMJPHa + _doesExist.InDirectEnergyMJPHa);

                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            InterCulture _doesExist = _context.InterCulture.Where(x => x.Id == Id).FirstOrDefault();

            _context.InterCulture.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
