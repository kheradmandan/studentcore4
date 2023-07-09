using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Controllers
{
    public class CI_FieldCourseController : Controller
    {
        private readonly StudentDbContext _context;
        private ICI_FieldCourse cI_FieldCourseRepository;
        public CI_FieldCourseController(StudentDbContext context)
        {
            _context = context;
            cI_FieldCourseRepository = new CI_FieldCourseRepository(_context);
        }

        // GET: CI_FieldCourse
        public ActionResult Index()
        {
            return View(cI_FieldCourseRepository.GetAllCI_FieldCourses());
          
        }

        // GET: CI_FieldCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            //if (id == null || _context.CI_FieldCourses == null)
            //{
            //    return NotFound();
            //}

            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id.Value);
            if (cI_FieldCourse == null)
            {
                return NotFound();
            }

            return View(cI_FieldCourse);
        }

        // GET: CI_FieldCourse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CI_FieldCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] CI_FieldCourse cI_FieldCourse)
        {
           
            if (ModelState.IsValid)
            {
                cI_FieldCourseRepository.InsertCI_FieldCourse(cI_FieldCourse);
                cI_FieldCourseRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cI_FieldCourse);
        }

        // GET: CI_FieldCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.CI_FieldCourses == null)
            //{
            //    return NotFound();
            //}

            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id.Value);
            if (cI_FieldCourse == null)
            {
                return NotFound();
            }
            return View(cI_FieldCourse);
        }

        // POST: CI_FieldCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] CI_FieldCourse cI_FieldCourse)
        {
            if (id != cI_FieldCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cI_FieldCourseRepository.UpdateCI_FieldCourse(cI_FieldCourse);
                    cI_FieldCourseRepository.Save();
                  
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var u = ex.Message.ToString();
                    if (!CI_FieldCourseExists(cI_FieldCourse.Id))
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
            return View(cI_FieldCourse);
        }

        // GET: CI_FieldCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.CI_FieldCourses == null)
            //{
            //    return NotFound();
            //}

            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id.Value);
            if (cI_FieldCourse == null)
            {
                return NotFound();
            }

            return View(cI_FieldCourse);
        }

        // POST: CI_FieldCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.CI_FieldCourses == null)
            //{
            //    return Problem("Entity set 'StudentDbContext.CI_FieldCourses'  is null.");
            //}
            var cI_FieldCourse = cI_FieldCourseRepository.GetCI_FieldCourseById(id);
            if (cI_FieldCourse != null)
            {
                cI_FieldCourseRepository.DeleteCI_FieldCourse(cI_FieldCourse);
            }

            cI_FieldCourseRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CI_FieldCourseExists(int id)
        {
            return false;
            //(_context.CI_FieldCourses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
