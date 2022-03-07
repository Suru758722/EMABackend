using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
    public class FarmerDetail: BaseEntity
    {        
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double LandHolding { get; set; }
        public int? CropId { get; set; }
        [ForeignKey("CropId")]
        public virtual Crop Crop { get; set; }
    }
}
