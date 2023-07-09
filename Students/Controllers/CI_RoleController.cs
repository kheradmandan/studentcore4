using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;

namespace Students.Controllers
{
    public class CI_RoleController : Controller
    {
        private readonly StudentDbContext _context;

        public CI_RoleController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: CI_Role
        public async Task<IActionResult> Index()
        {
              return _context.CI_Roles != null ? 
                          View(await _context.CI_Roles.ToListAsync()) :
                          Problem("Entity set 'StudentDbContext.CI_Roles'  is null.");
        }

        // GET: CI_Role/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CI_Roles == null)
            {
                return NotFound();
            }

            var cI_Role = await _context.CI_Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cI_Role == null)
            {
                return NotFound();
            }

            return View(cI_Role);
        }

        // GET: CI_Role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CI_Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cI_RoleId,Title")] CI_Role cI_Role)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cI_Role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cI_Role);
        }

        // GET: CI_Role/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CI_Roles == null)
            {
                return NotFound();
            }

            var cI_Role = await _context.CI_Roles.FindAsync(id);
            if (cI_Role == null)
            {
                return NotFound();
            }
            return View(cI_Role);
        }

        // POST: CI_Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cI_RoleId,Title")] CI_Role cI_Role)
        {
            if (id != cI_Role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cI_Role);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CI_RoleExists(cI_Role.Id))
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
            return View(cI_Role);
        }

        // GET: CI_Role/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CI_Roles == null)
            {
                return NotFound();
            }

            var cI_Role = await _context.CI_Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cI_Role == null)
            {
                return NotFound();
            }

            return View(cI_Role);
        }

        // POST: CI_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CI_Roles == null)
            {
                return Problem("Entity set 'StudentDbContext.CI_Roles'  is null.");
            }
            var cI_Role = await _context.CI_Roles.FindAsync(id);
            if (cI_Role != null)
            {
                _context.CI_Roles.Remove(cI_Role);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CI_RoleExists(int id)
        {
          return (_context.CI_Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
