using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectFromAeWebsite.Models;
using System.IO;

namespace FinalProjectFromAeWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubMenusController : Controller
    {
        private readonly FromAeDbContext _context;

        public SubMenusController(FromAeDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SubMenus
        public async Task<IActionResult> Index()
        {
            var fromAeDbContext = _context.SubMenus.Include(s => s.Menu);
            return View(await fromAeDbContext.ToListAsync());
        }

        // GET: Admin/SubMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subMenu = await _context.SubMenus
                .Include(s => s.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subMenu == null)
            {
                return NotFound();
            }

            return View(subMenu);
        }

        // GET: Admin/SubMenus/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name");
            return View();
        }

        // POST: Admin/SubMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubMenuViewModel sub)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = UploadedFile(sub);
                SubMenu sub1 = new SubMenu
                {
                    MainImg = uniqueFileName,
                    Name = sub.Name,
                    Link=sub.Link,
                    Menu=sub.Menu,
                    MenuId=sub.MenuId

                };
                _context.Add(sub1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", sub.MenuId);
            return View(sub);
        }
        private string UploadedFile(SubMenuViewModel model)
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

        // GET: Admin/SubMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subMenu = await _context.SubMenus.FindAsync(id);
            if (subMenu == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", subMenu.MenuId);
            return View(subMenu);
        }

        // POST: Admin/SubMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,SubMenuViewModel subMenu)
        {
            if (id != subMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var submenu =await _context.SubMenus.FindAsync(id);
                string uniqueFileName = UploadedFile(subMenu);
                submenu.MainImg = uniqueFileName;
                submenu.Name = subMenu.Name;
                submenu.Link = subMenu.Link;
                submenu.Menu = subMenu.Menu;
                submenu.MenuId = subMenu.MenuId;
               await _context.SaveChangesAsync();

                return RedirectToAction("Index","SubMenus");
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", subMenu.MenuId);
            return View(subMenu);
        }

        // GET: Admin/SubMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subMenu = await _context.SubMenus
                .Include(s => s.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subMenu == null)
            {
                return NotFound();
            }

            return View(subMenu);
        }

        // POST: Admin/SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subMenu = await _context.SubMenus.FindAsync(id);
            _context.SubMenus.Remove(subMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubMenuExists(int id)
        {
            return _context.SubMenus.Any(e => e.Id == id);
        }
    }
}
