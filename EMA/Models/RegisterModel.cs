using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Models
{
    public class RegisterModel: LoginModel
    {
        public string FullName { get; set; }
        public string ConfirmPassword  { get; set; }
    }
}
