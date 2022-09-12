﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicFarm.Models;

namespace OrganicFarm.Controllers
{
    public class TblRolesController : Controller
    {
        private readonly ShopContext _context;

        public TblRolesController(ShopContext context)
        {
            _context = context;
        }

        // GET: TblRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblRole.ToListAsync());
        }

        // GET: TblRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRole = await _context.TblRole
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tblRole == null)
            {
                return NotFound();
            }

            return View(tblRole);
        }

        // GET: TblRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName")] TblRole tblRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblRole);
        }

        // GET: TblRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRole = await _context.TblRole.FindAsync(id);
            if (tblRole == null)
            {
                return NotFound();
            }
            return View(tblRole);
        }

        // POST: TblRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName")] TblRole tblRole)
        {
            if (id != tblRole.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRoleExists(tblRole.RoleId))
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
            return View(tblRole);
        }

        // GET: TblRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRole = await _context.TblRole
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tblRole == null)
            {
                return NotFound();
            }

            return View(tblRole);
        }

        // POST: TblRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRole = await _context.TblRole.FindAsync(id);
            _context.TblRole.Remove(tblRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRoleExists(int id)
        {
            return _context.TblRole.Any(e => e.RoleId == id);
        }
    }
}
