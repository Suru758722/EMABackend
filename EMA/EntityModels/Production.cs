using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
    public class Production : BaseEntity
    {
        public int? Farmerid { get; set; }

        [ForeignKey("Farmerid")]
        public virtual FarmerDetail FarmerDetail { get; set; }
        public double GrainProduction { get; set; }
        public double StrawProduction { get; set; }
        public double Price { get; set; }
        public double TotalEnergyMJPHa { get; set; }
        public double GrainStrawRatio { get; set; }
        public double TotalEnergyGrainMJPHa { get; set; }
        public double TotalEnergyStrawMJPHa { get; set; }
    }
}
