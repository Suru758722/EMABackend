using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class MachineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ModelId { get; set; }
        public string MachineType { get; set; }
        public double HP { get; set; }
        public double WeightKg { get; set; }
        public double LifeHr { get; set; }
    }
}
