using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
