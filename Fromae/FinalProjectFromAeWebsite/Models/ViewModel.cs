using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Models
{
    public class ViewModel
    {
        public IEnumerable<Category> GetCategories { get; set; }
        public IEnumerable<Product> GetProducts { get; set; }
        public IEnumerable<ProductCategory> GetProductCategories { get; set; }
        public IEnumerable<ProductProperty> GetProductProperties { get; set; }
        public IEnumerable<Marka> GetMarkas { get; set; }
        public IEnumerable<Model> GetModels { get; set; }
        public IEnumerable<Menu> GetMenus { get; set; }
        public IEnumerable<SubMenu> GetSubMenus { get; set; }
        public IEnumerable<Rating> GetRatings { get; set; }
        public IEnumerable<Comment> GetComments { get; set; }
        public IEnumerable<Picture> GetPictures { get; set; }
        public IEnumerable<Property> GetProperties { get; set; }
    }
}
