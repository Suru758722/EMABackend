using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class InterCultureModel : SeedBeedModel
    {
        public string Machine { get; set; }
        public DateTime Date { get; set; }
        public string Material { get; set; }
        public decimal Qty { get; set; }
    }
}
