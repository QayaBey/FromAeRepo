using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectFromAeWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectFromAeWebsite.Controllers
{
    public class ProductController : Controller
    {
        public FromAeDbContext _dbContext;
        public List<Marka> markas = new List<Marka>();

        public ProductController(FromAeDbContext dbContex)
        {
            _dbContext = dbContex;
        }

        //public IActionResult SearchProduct(string str)
        //{

        //}
        public IActionResult ProductData(int id)
        {
           
            ViewBag.ProductName = _dbContext.Categories.Where(x => x.Id == id).Select(x => x.Name).ToList();
            ViewBag.Istehsalci = (from m in _dbContext.Markas
                                  join mo in _dbContext.Models
                      on m.Id equals mo.MarkaId
                                  join p in _dbContext.Products on mo.Id equals p.ModelId
                                  join pc in _dbContext.ProductCategories on p.Id equals pc.ProductId
                                  join c in _dbContext.Categories on pc.CategoryId equals c.Id
                                  where c.Id == id
                                  select m.Name).Distinct();

            ViewBag.PropValue =(from c in _dbContext.Categories
                                join pc in _dbContext.ProductCategories
                                on c.Id equals pc.CategoryId
                                join p in _dbContext.Products
                                on pc.ProductId equals p.Id
                                join pp in _dbContext.ProductProperties
                                on p.Id equals pp.ProductId
                                join pr in _dbContext.Properties
                                on pp.PropertyId equals pr.Id
                                where c.Id == id
                                select pp.Value).Distinct().ToList();
            ViewBag.Low = _dbContext.Products.Where(x => x.ProductCategories.Any(y => y.CategoryId == id)).OrderBy(x=>x.SalePrice).ToList();
            ViewBag.High = _dbContext.Products.Where(x => x.ProductCategories.Any(y => y.CategoryId == id)).OrderByDescending(x => x.SalePrice).ToList();

            var product = _dbContext.Products.Where(x => x.ProductCategories.Any(y => y.CategoryId == id));
            return View(product);
        }
        //public IActionResult SearchProduct(string str)
        //{
        //    var model = _dbContext.Products.Where(x => x.Name.Contains(str));
        //    return View(model);
        //}

    }
}