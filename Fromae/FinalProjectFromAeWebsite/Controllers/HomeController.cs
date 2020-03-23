using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProjectFromAeWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NUnit.Framework;

namespace FinalProjectFromAeWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public FromAeDbContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, FromAeDbContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.GetProperties = _dbcontext.Properties.ToList();
            viewModel.GetProducts = _dbcontext.Products.ToList();
            viewModel.GetRatings = _dbcontext.Ratings.ToList();
            viewModel.GetSubMenus = _dbcontext.SubMenus.ToList();
            viewModel.GetMenus = _dbcontext.Menus.ToList();
            viewModel.GetModels = _dbcontext.Models.ToList();
            viewModel.GetMarkas = _dbcontext.Markas.ToList();
            viewModel.GetProductCategories = _dbcontext.ProductCategories.ToList();
            viewModel.GetProductProperties = _dbcontext.ProductProperties.ToList();
            viewModel.GetPictures = _dbcontext.Pictures.ToList();
            viewModel.GetComments = _dbcontext.Comments.ToList();
            viewModel.GetCategories = _dbcontext.Categories.ToList();
            return View(viewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
