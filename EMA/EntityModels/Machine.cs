using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
    public class Machine: BaseEntity
    {
        
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ModelId { get; set; }
        public string MachineType { get; set; }
        public double HP { get; set; }
        public double WeightKg { get; set; }
        public double Energy{ get; set; }
        public double LifeHr { get; set; }

    }
}
