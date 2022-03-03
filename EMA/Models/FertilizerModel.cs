using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class FertilizerModel
    {
        public int Id { get; set; }
        public int Labourer { get; set; }
        public double Capacity { get; set; }     
        public int NoOfPass { get; set; }
        public string Material1 { get; set; }
        public double QtyKgPHa1 { get; set; }
        public string Material2 { get; set; }
        public double QtyKgPHa2 { get; set; }
        public string Material3 { get; set; }
        public double QtyKgPHa3 { get; set; }
        public string Material4 { get; set; }
        public double QtyKgPHa4 { get; set; }
        public int Farmerid { get; set; }
    }
}
