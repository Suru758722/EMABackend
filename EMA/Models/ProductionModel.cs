using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class ProductionModel
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public double GrainProduction { get; set; }
        public double StrawProduction { get; set; }
        public double Price { get; set; }
    }
}
