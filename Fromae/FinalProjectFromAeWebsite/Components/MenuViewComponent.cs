using FinalProjectFromAeWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFromAeWebsite.Components
{
    public class MenuViewComponent : ViewComponent
    {
        public FromAeDbContext _fromAeDb;
        public MenuViewComponent(FromAeDbContext fromAeDb)
        {
            _fromAeDb = fromAeDb;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _fromAeDb.Menus.Include("SubMenus").ToListAsync();
            return View(response);
        }
    }
}
