using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class FarmerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double LandHolding { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Take { get; set; }
        public bool MoreExist { get; set; }
        public string CropName { get; set; }
        public int CropId { get; set; }
    }
}
