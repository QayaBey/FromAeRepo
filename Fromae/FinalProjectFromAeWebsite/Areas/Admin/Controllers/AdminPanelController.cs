using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectFromAeWebsite.Controllers
{
    [Area("Admin")]
    public class AdminPanelController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}