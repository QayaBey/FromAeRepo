using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class Istifadeciler
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string FatherName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public string EmailAdress { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Orders>  Orders{get;set;}
    }
}
