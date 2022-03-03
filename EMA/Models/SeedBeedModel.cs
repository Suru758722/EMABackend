using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class SeedBeedModel
    {
        public int Id { get; set; }
        public string TypeOperation { get; set; }
        public string OwnHired { get; set; }
        public double Rate { get; set; }
        public double DieselLPH { get; set; }
        public int DriverLabour { get; set; }
        public int NoOfPass { get; set; }
        public int FarmerId { get; set; }
        public int MachineId { get; set; }
        public int EquipmentId { get; set; }
    }
}
