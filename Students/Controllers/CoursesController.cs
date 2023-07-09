using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Controllers
{
    public class CoursesController : Controller
    {
        private readonly StudentDbContext _context;
        private ICourse courseRepository;
        private ICI_FieldCourse cI_FieldCourseRepository;



        public CoursesController(StudentDbContext context)
        {
            _context = context;
            courseRepository = new CourseRepository(_context);
            cI_FieldCourseRepository = new CI_FieldCourseRepository(_context);
        }

        // GET: Courses
        public IActionResult Index()
        {
            return View(courseRepository.GetAllCourses());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Courses == null)
            //{
            //    return NotFound();
            //}

            var course = courseRepository.GetCourseById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["CI_FieldCourseId"] = new SelectList(_context.CI_FieldCourses, "Id", "Title");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Classtime,TimeOfSession,TeacherId,CI_FieldCourseId")] Course course)
        {

           // course.CI_FieldCourse.Title= cI_FieldCourseRepository.GetCI_FieldCourseById(course.CI_FieldCourseId).Title;
            if (ModelState.IsValid)
            {

                courseRepository.InsertCourse(course);
                var t = 0;
                courseRepository.Save();
            
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_FieldCourseId"] = new SelectList(_context.CI_FieldCourses, "Id", "Title", course.CI_FieldCourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", course.TeacherId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.Courses == null)
            //{
            //    return NotFound();
            //}

            var course = courseRepository.GetCourseById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CI_FieldCourseId"] = new SelectList(_context.CI_FieldCourses, "Id", "Title", course.CI_FieldCourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", course.TeacherId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Classtime,TimeOfSession,TeacherId,CI_FieldCourseId")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    courseRepository.UpdateCourse(course);
                    courseRepository.Save();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["CI_FieldCourseId"] = new SelectList(_context.CI_FieldCourses, "Id", "Title", course.CI_FieldCourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", course.TeacherId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Courses == null)
            //{
            //    return NotFound();
            //}

            var course = courseRepository.GetCourseById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'StudentDbContext.Courses'  is null.");
            }
            var course = courseRepository.GetCourseById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            courseRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return false;
            //(_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
