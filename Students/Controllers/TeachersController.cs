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
    public class TeachersController : Controller
    {
        private readonly StudentDbContext _context;
        private ITeacher teacherRepository;

        public TeachersController(StudentDbContext context)
        {
            _context = context;
            teacherRepository = new TeacherRepository(_context);
        }

        // GET: Teachers
        public IActionResult Index()
        {
            return View(teacherRepository.GetAllTeachers());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Teachers == null)
            //{
            //    return NotFound();
            //}

            var teacher = teacherRepository.GetTeacherById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mob")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherRepository.InsertTeacher(teacher);
                teacherRepository.Save();
               
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.Teachers == null)
            //{
            //    return NotFound();
            //}

            var teacher = teacherRepository.GetTeacherById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mob")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    teacherRepository.UpdateTeacher(teacher);
                    teacherRepository.Save();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Teachers == null)
            //{
            //    return NotFound();
            //}

            var teacher = teacherRepository.GetTeacherById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teachers == null)
            {
                return Problem("Entity set 'StudentDbContext.Teachers'  is null.");
            }
            var teacher = teacherRepository.GetTeacherById(id);
            if (teacher != null)
            {
                teacherRepository.DeleteTeacher(teacher);
                teacherRepository.Save();
               
            }
            
           
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return false;
            //(_context.Teachers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
