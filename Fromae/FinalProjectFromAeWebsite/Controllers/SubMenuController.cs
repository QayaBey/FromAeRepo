using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectFromAeWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectFromAeWebsite.Controllers
{
    public class SubMenuController : Controller
    {
        public FromAeDbContext _dbcontext;
        public SubMenuController(FromAeDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        public IActionResult SubMenu(int id)
        {
            var submenu = _dbcontext.SubMenus.Where(x => x.MenuId == id).ToList();
            ViewBag.SubsName = _dbcontext.Menus.Where(x => x.Id == id).Select(x => x.Name).ToList();
            return View(submenu);
        }
    }
}