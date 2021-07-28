using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.EfStuff.Model
{
    public class Aptechka : BaseModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Color { get; set; }
        public string AdditionalDescription { get; set; }
        public string AptechkaPictureUrl { get; set; }
        public virtual User Owner { get; set; }
        public virtual List<Drug> Drugs { get; set; }
    }
}