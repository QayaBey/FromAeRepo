using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class ProductProperty
    {
        public string Value { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
