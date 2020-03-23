using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectFromAeWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectFromAeWebsite.Controllers
{
    public class CategoryController : Controller
    {
        public FromAeDbContext _dbContext;
        public CategoryController(FromAeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult CategoryData(int id)
        {
            ViewBag.CategoryName = _dbContext.SubMenus.Where(x => x.Id == id).Select(x => x.Name).ToList();
            var category = _dbContext.Categories.Where(x => x.SubMenuId== id).ToList();
            return View(category);
        }
    }
}