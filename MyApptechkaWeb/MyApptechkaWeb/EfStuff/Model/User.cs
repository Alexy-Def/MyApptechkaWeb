using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.EfStuff.Model
{
    public class User : BaseModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}