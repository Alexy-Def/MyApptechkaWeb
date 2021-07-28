using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.EfStuff.Model
{
    public class Drug : BaseModel
    {
        public string Name { get; set; }
        public string Form { get; set; }
        public string Purpose { get; set; }
        public string ExpiryDate { get; set; }
        public string Residue { get; set; }
        public string AdditionalDescription { get; set; }
        public virtual Aptechka AptechkaOwner { get; set; }
    }
}