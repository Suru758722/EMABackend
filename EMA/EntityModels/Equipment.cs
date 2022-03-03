using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }      
        public string EquipmentType { get; set; }
        public string Size { get; set; }
        public double WeightKG { get; set; }
        public double LifeHr { get; set; }
        public double Capacity { get; set; }
        public double Energy { get; set; }
    }
}
