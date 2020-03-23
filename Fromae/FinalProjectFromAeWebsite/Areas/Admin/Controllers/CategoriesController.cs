using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectFromAeWebsite.Models;
using System.IO;

namespace FinalProjectFromAeWebsite.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly FromAeDbContext _context;

        public CategoriesController(FromAeDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var fromAeDbContext = _context.Categories.Include(c => c.SubMenu);
            return View(await fromAeDbContext.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.SubMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["SubMenuId"] = new SelectList(_context.SubMenus, "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                string unqueFileName = UploadedFile(category);
                Category category1 = new Category
                {
                    Name = category.Name,
                    Link = category.Link,
                    ProductCategories = category.ProductCategories,
                    SubMenu = category.SubMenu,
                    MainImg = unqueFileName,
                    SubMenuId = category.SubMenuId

                };
                _context.Add(category1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SubMenuId"] = new SelectList(_context.SubMenus, "Id", "Name", category.SubMenuId);
            return View(category);
        }
        private string UploadedFile(CategoryViewModel model)
        {
            string uniqueFileName = null;

            if (model.MainImg != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MainImg.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.MainImg.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["SubMenuId"] = new SelectList(_context.SubMenus, "Id", "Name", category.SubMenuId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryViewModel category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(category);
                var editModel = await _context.Categories.FindAsync(id);

                editModel.MainImg = uniqueFileName;
                editModel.Name = category.Name;
                editModel.Link = category.Link;
                editModel.ProductCategories = category.ProductCategories;
                editModel.SubMenu = category.SubMenu;
                editModel.SubMenuId = category.SubMenuId;

                //_context.Add(editModel);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index", "Categoies");
            }
            ViewData["SubMenuId"] = new SelectList(_context.SubMenus, "Id", "Name", category.SubMenuId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.SubMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
