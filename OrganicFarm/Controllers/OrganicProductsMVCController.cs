using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicFarm.Models;

namespace OrganicFarm.Controllers
{
    public class OrganicProductsMVCController : Controller
    {
        private readonly ShopContext _context;

        public OrganicProductsMVCController(ShopContext context)
        {
            _context = context;
        }

        // GET: OrganicProductsMVC
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.OrganicProduct.Include(o => o.OrganicShop);
            return View(await shopContext.ToListAsync());
        }

        // GET: OrganicProductsMVC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicProduct = await _context.OrganicProduct
                .Include(o => o.OrganicShop)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (organicProduct == null)
            {
                return NotFound();
            }

            return View(organicProduct);
        }

        // GET: OrganicProductsMVC/Create
        public IActionResult Create()
        {
            ViewData["OrganicShopId"] = new SelectList(_context.OrganicShop, "ShopId", "ShopId");
            return View();
        }

        // POST: OrganicProductsMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Price,ProductType,ExpiryDate,OrganicShopId")] OrganicProduct organicProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organicProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganicShopId"] = new SelectList(_context.OrganicShop, "ShopId", "ShopId", organicProduct.OrganicShopId);
            return View(organicProduct);
        }

        // GET: OrganicProductsMVC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicProduct = await _context.OrganicProduct.FindAsync(id);
            if (organicProduct == null)
            {
                return NotFound();
            }
            ViewData["OrganicShopId"] = new SelectList(_context.OrganicShop, "ShopId", "ShopId", organicProduct.OrganicShopId);
            return View(organicProduct);
        }

        // POST: OrganicProductsMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Price,ProductType,ExpiryDate,OrganicShopId")] OrganicProduct organicProduct)
        {
            if (id != organicProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organicProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganicProductExists(organicProduct.ProductId))
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
            ViewData["OrganicShopId"] = new SelectList(_context.OrganicShop, "ShopId", "ShopId", organicProduct.OrganicShopId);
            return View(organicProduct);
        }

        // GET: OrganicProductsMVC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicProduct = await _context.OrganicProduct
                .Include(o => o.OrganicShop)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (organicProduct == null)
            {
                return NotFound();
            }

            return View(organicProduct);
        }

        // POST: OrganicProductsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organicProduct = await _context.OrganicProduct.FindAsync(id);
            _context.OrganicProduct.Remove(organicProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganicProductExists(int id)
        {
            return _context.OrganicProduct.Any(e => e.ProductId == id);
        }
    }
}
