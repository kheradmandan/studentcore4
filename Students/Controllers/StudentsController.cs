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
    public class StudentsController : Controller
    {
        private readonly StudentDbContext _context;
        private IStudent studentRepository;
        private ICI_FieldStudent cI_FieldStudentRepository;

        public StudentsController(StudentDbContext context)
        {
            _context = context;
            studentRepository = new StudentRepository(_context);
            cI_FieldStudentRepository=new CI_FieldStudentRepository(_context);
        }

        // GET: Students
        public IActionResult Index()
        {
           var t = studentRepository.GetAllStudents().ToList();
            return View(studentRepository.GetAllStudents());
           
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Students == null)
            //{
            //    return NotFound();
            //}

            var student = studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CI_FieldStudentId"] = new SelectList(_context.CI_FieldStudents, "Id", "Title");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Create([Bind("Id,Name,Age,CI_FieldStudentId")] Student student)


            public ActionResult Create([Bind("Id,Name,NationalCode,Age,CI_FieldStudentId")] Student student)

        {
           // student.Field = "test";
           //student.CI_FieldStudent.Id= student.CI_FieldStudentId;
          //  student.CI_FieldStudent.Title = cI_FieldStudentRepository.GetCI_FieldStudentById(student.CI_FieldStudentId).Title;
           // cI_FieldStudentRepository.Save();
            if (ModelState.IsValid)
            {
                studentRepository.InsertStudent(student);
                studentRepository.Save();
             
                return RedirectToAction(nameof(Index));
            }
            ViewData["CI_FieldStudentId"] = new SelectList(_context.CI_FieldStudents, "Id", "Title", student.CI_FieldStudentId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.Students == null)
            //{
            //    return NotFound();
            //}

            var student = studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CI_FieldStudentId"] = new SelectList(_context.CI_FieldStudents, "Id", "Title", student.CI_FieldStudentId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NationalCode,Age,Field,CI_FieldStudentId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    studentRepository.UpdateStudent(student);
                    studentRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["CI_FieldStudentId"] = new SelectList(_context.CI_FieldStudents, "Id", "Title", student.CI_FieldStudentId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Students == null)
            //{
            //    return NotFound();
            //}

            var student = studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'StudentDbContext.Students'  is null.");
            }
            var student = studentRepository.GetStudentById(id);
            if (student != null)
            {
                studentRepository.DeleteStudent(student);
                studentRepository.Save();
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return false;
            //(_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
