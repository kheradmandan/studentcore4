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
    public class CI_FieldStudentController : Controller
    {
        private readonly StudentDbContext _context;
        private ICI_FieldStudent cI_FieldStudentRepository;

        public CI_FieldStudentController(StudentDbContext context)
        {
            _context = context;
            cI_FieldStudentRepository = new CI_FieldStudentRepository(_context);
        }

        // GET: CI_FieldStudent
        public IActionResult Index()
        {
            return View(cI_FieldStudentRepository.GetAllCI_FieldStudents());
        }

        // GET: CI_FieldStudent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.CI_FieldStudents == null)
            //{
            //    return NotFound();
            //}

            var cI_FieldStudent = cI_FieldStudentRepository.GetCI_FieldStudentById(id.Value);
            if (cI_FieldStudent == null)
            {
                return NotFound();
            }

            return View(cI_FieldStudent);
        }

        // GET: CI_FieldStudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CI_FieldStudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] CI_FieldStudent cI_FieldStudent)
        {
            if (ModelState.IsValid)
            {
                cI_FieldStudentRepository.InsertCI_FieldStudent(cI_FieldStudent);
                cI_FieldStudentRepository.Save();            
                return RedirectToAction(nameof(Index));
            }
            return View(cI_FieldStudent);
        }

        // GET: CI_FieldStudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.CI_FieldStudents == null)
            //{
            //    return NotFound();
            //}

            var cI_FieldStudent = cI_FieldStudentRepository.GetCI_FieldStudentById(id.Value);
            if (cI_FieldStudent == null)
            {
                return NotFound();
            }
            return View(cI_FieldStudent);
        }

        // POST: CI_FieldStudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] CI_FieldStudent cI_FieldStudent)
        {
            if (id != cI_FieldStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cI_FieldStudentRepository.UpdateCI_FieldStudent(cI_FieldStudent);
                    cI_FieldStudentRepository.Save();
           
             
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CI_FieldStudentExists(cI_FieldStudent.Id))
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
            return View(cI_FieldStudent);
        }

        // GET: CI_FieldStudent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.CI_FieldStudents == null)
            //{
            //    return NotFound();
            //}

            var cI_FieldStudent = cI_FieldStudentRepository.GetCI_FieldStudentById(id.Value);
            if (cI_FieldStudent == null)
            {
                return NotFound();
            }

            return View(cI_FieldStudent);
        }

        // POST: CI_FieldStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CI_FieldStudents == null)
            {
                return Problem("Entity set 'StudentDbContext.CI_FieldStudents'  is null.");
            }
            var cI_FieldStudent = cI_FieldStudentRepository.GetCI_FieldStudentById(id);
            if (cI_FieldStudent != null)
            {
                cI_FieldStudentRepository.DeleteCI_FieldStudent(cI_FieldStudent);
                cI_FieldStudentRepository.Save();
            }
            
       
            return RedirectToAction(nameof(Index));
        }

        private bool CI_FieldStudentExists(int id)
        {
            return false;
                //(_context.CI_FieldStudents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
