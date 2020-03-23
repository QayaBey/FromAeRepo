using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class PictureViewModel
    {
        public int Id { get; set; }
        public IFormFile[] MainImg { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
