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
    public interface IFertilizerService
    {
        dynamic GetData(int take);
        bool AddUpdate(FertilizerModel data);
        bool Delete(int Id);
    }
    public class FertilizerService : IFertilizerService
    {
        readonly ApplicationDbContext _context;
        public FertilizerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public dynamic GetData(int take)
        {
            var list =  _context.Fertilizer.Include(x => x.FarmerDetail).ThenInclude(x => x.Crop).AsQueryable();
            bool moreExist = false;
            int total = list.Count() - (take - 1) * 2;
            if (total > 2)
                moreExist = true;
            else
                moreExist = false;
            return new { take = take, exist = moreExist, list = list.Skip((take - 1) * 2).Take(2).ToList() };

        }
        public bool AddUpdate(FertilizerModel data)
        {
           
            Fertilizer _doesExist = _context.Fertilizer.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {

                Fertilizer _detail = new Fertilizer();
                _detail.Labourer = data.Labourer;
                _detail.Farmerid = data.Farmerid;
                _detail.Capacity = data.Capacity;               
                _detail.HumanEnergy = 1.96 * data.Labourer;
                _detail.DirectEnergyMJPH = _detail.HumanEnergy;
                _detail.DirectEnergyMJPHa = _detail.DirectEnergyMJPH * (1 / data.Capacity);
                _detail.NoOfPass = data.NoOfPass;
                _detail.TotalDirectEnergyMJPHa = _detail.DirectEnergyMJPHa * data.NoOfPass;
                _detail.Material1 = data.Material1;
                _detail.Material2 = data.Material2;
                _detail.Material3 = data.Material3;
                _detail.Material4 = data.Material4;
                _detail.QtyKgPHa1 = data.QtyKgPHa1;
                _detail.QtyKgPHa2 = data.QtyKgPHa2;
                _detail.QtyKgPHa3 = data.QtyKgPHa3;
                _detail.QtyKgPHa4 = data.QtyKgPHa4;
                _detail.InDirectEnergyMJPHa = (data.QtyKgPHa1 * 0.18 * 60.6) + (data.QtyKgPHa2 * 0.46 * 11.1) + (data.QtyKgPHa3 * 0.46 * 60.6) + (data.QtyKgPHa4 * 0.3);
                _detail.OperationalEnergy = (_detail.TotalDirectEnergyMJPHa + _detail.InDirectEnergyMJPHa);
                _detail.TotalEnergy = _detail.OperationalEnergy;
                _context.Fertilizer.Add(_detail);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.Labourer = data.Labourer;
                _doesExist.Farmerid = data.Farmerid;
                _doesExist.Capacity = data.Capacity;
                _doesExist.HumanEnergy = 1.96 * data.Labourer;
                _doesExist.DirectEnergyMJPH = _doesExist.HumanEnergy;
                _doesExist.DirectEnergyMJPHa = _doesExist.DirectEnergyMJPH * (1 / data.Capacity);
                _doesExist.NoOfPass = data.NoOfPass;
                _doesExist.TotalDirectEnergyMJPHa = _doesExist.DirectEnergyMJPHa * data.NoOfPass;
                _doesExist.Material1 = data.Material1;
                _doesExist.Material2 = data.Material2;
                _doesExist.Material3 = data.Material3;
                _doesExist.Material4 = data.Material4;
                _doesExist.QtyKgPHa1 = data.QtyKgPHa1;
                _doesExist.QtyKgPHa2 = data.QtyKgPHa2;
                _doesExist.QtyKgPHa3 = data.QtyKgPHa3;
                _doesExist.QtyKgPHa4 = data.QtyKgPHa4;
                _doesExist.InDirectEnergyMJPHa = (data.QtyKgPHa1 * 0.18 * 60.6) + (data.QtyKgPHa2 * 0.46 * 11.1) + (data.QtyKgPHa3 * 0.46 * 60.6) + (data.QtyKgPHa4 * 0.3);
                _doesExist.OperationalEnergy = (_doesExist.TotalDirectEnergyMJPHa + _doesExist.InDirectEnergyMJPHa);
                _doesExist.TotalEnergy = _doesExist.OperationalEnergy;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            Fertilizer _doesExist = _context.Fertilizer.Where(x => x.Id == Id).FirstOrDefault();

            _context.Fertilizer.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
