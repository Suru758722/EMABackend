using EMA.Data;
using EMA.EntityModels;
using EMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface IProductionService
    {
        List<Production> GetData();
        bool AddUpdate(ProductionModel data);
        bool Delete(int Id);
    }
    public class ProductionService : IProductionService
    {
        readonly ApplicationDbContext _context;
        public ProductionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Production> GetData()
        {
            return _context.Production.ToList();
        }
        public bool AddUpdate(ProductionModel data)
        {

            Production _doesExist = _context.Production.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {

                Production _detail = new Production();
                _detail.Farmerid = data.FarmerId;
                _detail.GrainProduction = data.GrainProduction;
                _detail.StrawProduction = data.StrawProduction;
                _detail.Price = data.Price;
                _detail.TotalEnergyMJPHa = (data.GrainProduction * 14.7 * 100) + (data.StrawProduction * 12.5 * 100);
                _detail.TotalEnergyStrawMJPHa = 14.7 * data.StrawProduction * 100;
                _detail.TotalEnergyGrainMJPHa = 14.7 * data.GrainProduction * 100;
                _detail.GrainStrawRatio = data.GrainProduction / data.StrawProduction;
                _context.Production.Add(_detail);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.Farmerid = data.FarmerId;
                _doesExist.GrainProduction = data.GrainProduction;
                _doesExist.StrawProduction = data.StrawProduction;
                _doesExist.Price = data.Price;
                _doesExist.TotalEnergyMJPHa = (data.GrainProduction * 14.7 * 100) + (data.StrawProduction * 12.5 * 100);
                _doesExist.TotalEnergyStrawMJPHa = 14.7 * data.StrawProduction * 100;
                _doesExist.TotalEnergyGrainMJPHa = 14.7 * data.GrainProduction * 100;
                _doesExist.GrainStrawRatio = data.GrainProduction / data.StrawProduction;
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            Production _doesExist = _context.Production.Where(x => x.Id == Id).FirstOrDefault();

            _context.Production.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
