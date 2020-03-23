using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectFromAeWebsite.Models;

namespace FinalProjectFromAeWebsite.Controllers
{
    [Area("Admin")]
    public class ProductPropertiesController : Controller
    {
        private readonly FromAeDbContext _context;

        public ProductPropertiesController(FromAeDbContext context)
        {
            _context = context;
        }

        // GET: ProductProperties
        public async Task<IActionResult> Index()
        {
            var fromAeDbContext = _context.ProductProperties.Include(p => p.Product).Include(p => p.Property);
            return View(await fromAeDbContext.ToListAsync());
        }

        // GET: ProductProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productProperty = await _context.ProductProperties
                .Include(p => p.Product)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (productProperty == null)
            {
                return NotFound();
            }

            return View(productProperty);
        }

        // GET: ProductProperties/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Name");
            return View();
        }

        // POST: ProductProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,ProductId,PropertyId")] ProductProperty productProperty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productProperty.ProductId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Name", productProperty.PropertyId);
            return View(productProperty);
        }

        // GET: ProductProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productProperty = await _context.ProductProperties.FindAsync(id);
            if (productProperty == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productProperty.ProductId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Name", productProperty.PropertyId);
            return View(productProperty);
        }

        // POST: ProductProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Value,ProductId,PropertyId")] ProductProperty productProperty)
        {
            if (id != productProperty.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPropertyExists(productProperty.PropertyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productProperty.ProductId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Name", productProperty.PropertyId);
            return View(productProperty);
        }

        // GET: ProductProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productProperty = await _context.ProductProperties
                .Include(p => p.Product)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (productProperty == null)
            {
                return NotFound();
            }

            return View(productProperty);
        }

        // POST: ProductProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productProperty = await _context.ProductProperties.FindAsync(id);
            _context.ProductProperties.Remove(productProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPropertyExists(int id)
        {
            return _context.ProductProperties.Any(e => e.PropertyId == id);
        }
    }
}
