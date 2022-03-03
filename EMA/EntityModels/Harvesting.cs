using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
    public class Harvesting : BaseEntity
    {
        public int? Farmerid { get; set; }

        [ForeignKey("Farmerid")]
        public virtual FarmerDetail FarmerDetail { get; set; }
        public string TypeOperation { get; set; }
        public string OwnHired { get; set; }
        public double Rate { get; set; }
        public double DieselLPH { get; set; }
        public double FuelEnergy { get; set; }
        public int DriverLabour { get; set; }
        public double HumanEnergy { get; set; }
        public double DirectEnergyMJPH { get; set; }
        public double DirectEnergyMJPHa { get; set; }
        public int NoOfPass { get; set; }
        public double InDirectEnergyMJPH { get; set; }
        public double InDirectEnergyMJPHa { get; set; }
        public double OperationalEnergy { get; set; }
        public double LabourChargePDay { get; set; }
        public double TotalEnergy { get; set; }
        public int? EquipmentId { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
        public int? MachineId { get; set; }

        [ForeignKey("MachineId")]
        public virtual Machine Machine { get; set; }

      
    }
}
