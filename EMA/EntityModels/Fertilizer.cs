using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
    public class Fertilizer : BaseEntity
    {
      
        public int Labourer { get; set; }
        public double Capacity { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public string Material1 { get; set; }
        public double QtyKgPHa1 { get; set; }
        public string Material2 { get; set; }
        public double QtyKgPHa2 { get; set; }
        public string Material3 { get; set; }
        public double QtyKgPHa3 { get; set; }
        public string Material4 { get; set; }
        public double QtyKgPHa4 { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public double TotalEnergy { get; set; }
        public int? Farmerid { get; set; }

        [ForeignKey("Farmerid")]
        public virtual FarmerDetail FarmerDetail { get; set; }
    }
}
