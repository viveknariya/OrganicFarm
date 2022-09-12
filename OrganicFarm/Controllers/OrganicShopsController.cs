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
    public class OrganicShopsController : Controller
    {
        private readonly ShopContext _context;

        public OrganicShopsController(ShopContext context)
        {
            _context = context;
        }

        // GET: OrganicShops
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganicShop.ToListAsync());
        }

        // GET: OrganicShops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicShop = await _context.OrganicShop
                .FirstOrDefaultAsync(m => m.ShopId == id);
            if (organicShop == null)
            {
                return NotFound();
            }

            return View(organicShop);
        }

        // GET: OrganicShops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganicShops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopId,ShopName,Country,ShopAddress")] OrganicShop organicShop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organicShop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organicShop);
        }

        // GET: OrganicShops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicShop = await _context.OrganicShop.FindAsync(id);
            if (organicShop == null)
            {
                return NotFound();
            }
            return View(organicShop);
        }

        // POST: OrganicShops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopId,ShopName,Country,ShopAddress")] OrganicShop organicShop)
        {
            if (id != organicShop.ShopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organicShop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganicShopExists(organicShop.ShopId))
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
            return View(organicShop);
        }

        // GET: OrganicShops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicShop = await _context.OrganicShop
                .FirstOrDefaultAsync(m => m.ShopId == id);
            if (organicShop == null)
            {
                return NotFound();
            }

            return View(organicShop);
        }

        // POST: OrganicShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organicShop = await _context.OrganicShop.FindAsync(id);
            _context.OrganicShop.Remove(organicShop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganicShopExists(int id)
        {
            return _context.OrganicShop.Any(e => e.ShopId == id);
        }
    }
}
