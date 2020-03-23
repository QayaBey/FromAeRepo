using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class Product
    {
        public Product()
        {
            CreationDate = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public byte? Discount { get; set; }
        public decimal? SalePrice { get; set; }
        public string MainImg { get; set; }

        public DateTime CreationDate { get; set; }

        public Model Model { get; set; }
        public int ModelId { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductProperty> ProductProperties { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
