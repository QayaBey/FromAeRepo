using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class Orders
    {

        public Orders()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int IstifadecilerId { get; set; }
        public Istifadeciler Istifadeciler { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
