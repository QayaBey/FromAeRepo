using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class SubMenuViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Link { get; set; }

        public IFormFile MainImg { get; set; }

        public Menu Menu { get; set; }
        public int MenuId { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
