﻿using EMA.Data;
using EMA.EntityModels;
using EMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface IHarvestingService
    {
        List<Harvesting> GetData();
        bool AddUpdate(HarvestingModel data);
        bool Delete(int Id);
    }
    public class HarvestingService : IHarvestingService
    {
        readonly ApplicationDbContext _context;
        public HarvestingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Harvesting> GetData()
        {
            return _context.Harvesting.ToList();
        }
        public bool AddUpdate(HarvestingModel data)
        {
            Equipment equipment = _context.Equipment.Where(x => x.Id == data.EquipmentId).FirstOrDefault();
            double _machineEnergy = _context.Machine.Where(x => x.Id == data.MachineId).FirstOrDefault().Energy;
            Harvesting _doesExist = _context.Harvesting.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {

                Harvesting _detail = new Harvesting();
                _detail.TypeOperation = data.TypeOperation;
                _detail.Farmerid = data.FarmerId;
                _detail.MachineId = data.MachineId;
                _detail.EquipmentId = data.EquipmentId;
                _detail.OwnHired = data.OwnHired;
                _detail.Rate = data.Rate;
                _detail.DieselLPH = data.DieselLPH;
                _detail.FuelEnergy = 56.31 * data.DieselLPH;
                _detail.DriverLabour = data.DriverLabour;
                _detail.LabourChargePDay = data.LabourChargePDay;
                _detail.HumanEnergy = 1.96 * data.DriverLabour;
                _detail.DirectEnergyMJPH = _detail.HumanEnergy + _detail.FuelEnergy;
                _detail.DirectEnergyMJPHa = _detail.DirectEnergyMJPH * (1 / equipment.Capacity);
                _detail.NoOfPass = data.NoOfPass;
                _detail.InDirectEnergyMJPH = _machineEnergy + equipment.Energy;
                _detail.InDirectEnergyMJPHa = _detail.InDirectEnergyMJPH * (1 / equipment.Capacity);
                _detail.OperationalEnergy = (_detail.DirectEnergyMJPHa + _detail.InDirectEnergyMJPHa) * data.NoOfPass;
                _context.Harvesting.Add(_detail);
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
                _doesExist.LabourChargePDay = data.LabourChargePDay;
                _doesExist.HumanEnergy = 1.96 * data.DriverLabour;
                _doesExist.DirectEnergyMJPH = _doesExist.HumanEnergy + _doesExist.FuelEnergy;
                _doesExist.DirectEnergyMJPHa = _doesExist.DirectEnergyMJPH * (1 / equipment.Capacity);
                _doesExist.NoOfPass = data.NoOfPass;
                _doesExist.InDirectEnergyMJPH = _machineEnergy + equipment.Energy;
                _doesExist.InDirectEnergyMJPHa = _doesExist.InDirectEnergyMJPH * (1 / equipment.Capacity);
                _doesExist.OperationalEnergy = (_doesExist.DirectEnergyMJPHa + _doesExist.InDirectEnergyMJPHa) * data.NoOfPass;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            Harvesting _doesExist = _context.Harvesting.Where(x => x.Id == Id).FirstOrDefault();

            _context.Harvesting.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
