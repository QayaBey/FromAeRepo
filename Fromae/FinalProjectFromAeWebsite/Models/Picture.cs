using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string MainImg { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
