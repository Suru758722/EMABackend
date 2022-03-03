using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
    public class Irrigation : BaseEntity
    {
        public int? Farmerid { get; set; }

        [ForeignKey("Farmerid")]
        public virtual FarmerDetail FarmerDetail { get; set; }
        public string OwnHired { get; set; }
        public double EleckWh { get; set; }
        public double ElecEnergy { get; set; }
        public int OperatorLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double TimeTaken { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double TotalDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public int? EquipmentId { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
        public int? MachineId { get; set; }

        [ForeignKey("MachineId")]
        public virtual Machine Machine { get; set; }
    }
}
