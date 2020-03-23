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
    public class ProductsController : Controller
    {
        private readonly FromAeDbContext _context;

        public ProductsController(FromAeDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var fromAeDbContext = _context.Products.Include(p => p.Model);
            return View(await fromAeDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = UploadedFile(product);
                Product newProduct = new Product
                {

                    MainImg = uniqueFileName,
                    Name = product.Name,
                    Price = product.Price,
                    SalePrice = product.SalePrice,
                    Discount = product.Discount,
                    ModelId = product.ModelId,
                    Comments = product.Comments,
                    Pictures = product.Pictures,
                    ProductCategories = product.ProductCategories,
                    ProductProperties = product.ProductProperties,
                    Ratings = product.Ratings,
                    Model = product.Model

                };
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", product.ModelId);
            return View(product);
        }
       
        private string UploadedFile(ProductViewModel model)
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


        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", product.ModelId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(product);
                var editModel=  await  _context.Products.FindAsync(id);

                editModel.MainImg = uniqueFileName;
                editModel.Name = product.Name;
                editModel.Price = product.Price;
                editModel.SalePrice = product.SalePrice;
                editModel.Discount = product.Discount;
                editModel.ModelId = product.ModelId;
                editModel.Comments = product.Comments;
                editModel.Pictures = product.Pictures;
                editModel.ProductCategories = product.ProductCategories;
                editModel.ProductProperties = product.ProductProperties;
                editModel.Ratings = product.Ratings;
                editModel.Model = product.Model;

               //_context.Add(editModel);
              await  _context.SaveChangesAsync();


                return RedirectToAction("Index","Products");
            }
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", product.ModelId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
