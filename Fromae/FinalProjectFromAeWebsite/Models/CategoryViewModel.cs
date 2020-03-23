using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        public IFormFile MainImg { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Link { get; set; }
        public SubMenu SubMenu { get; set; }
        public int SubMenuId { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
