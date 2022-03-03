using EMA.Data;
using EMA.EntityModels;
using EMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface IEquipmentService
    {
        List<Equipment> GetData();
        bool AddUpdate(EquipmentModel data);
        bool Delete(int Id);
    }
    public class EquipmentService : IEquipmentService
    {
        readonly ApplicationDbContext _context;
        public EquipmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Equipment> GetData()
        {
            return _context.Equipment.ToList();

        }

        public bool AddUpdate(EquipmentModel data)
        {
            Equipment _doesExist = _context.Equipment.Where(x => x.Id == data.Id).FirstOrDefault();
            if (_doesExist == null)
            {
                Equipment _detail = new Equipment();
                _detail.Name = data.Name;
                _detail.EquipmentType = data.EquipmentType;
                _detail.Size = data.Size;
                _detail.WeightKG = data.WeightKG;
                _detail.LifeHr = data.LifeHr;
                _detail.Capacity = data.Capacity;
                _detail.Energy = 62.7 * (data.WeightKG / data.LifeHr);
                _context.Equipment.Add(_detail);
                _context.SaveChanges();

            }
            else
            {
                _doesExist.Name = data.Name;
                _doesExist.EquipmentType = data.EquipmentType;
                _doesExist.Size = data.Size;
                _doesExist.WeightKG = data.WeightKG;
                _doesExist.LifeHr = data.LifeHr;
                _doesExist.Capacity = data.Capacity;
                _doesExist.Energy = 62.7 * (data.WeightKG / data.LifeHr);
                _context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int Id)
        {
            Equipment _doesExist = _context.Equipment.Where(x => x.Id == Id).FirstOrDefault();

            _context.Equipment.Remove(_doesExist);
            _context.SaveChanges();
            return true;
        }
    }
}
