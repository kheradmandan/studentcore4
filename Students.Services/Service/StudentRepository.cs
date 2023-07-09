using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Service
{
    public class StudentRepository : IStudent
    {
        private StudentDbContext db;
        public StudentRepository(StudentDbContext _context)
        {
            this.db = _context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.Students;
        }

        public Student GetStudentById(int StudentId)
        {
            return db.Students.Find(StudentId);
        }

        public bool InsertStudent(Student student)
        {
            try
            {
                db.Students.Add(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                db.Entry(student).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        public bool DeleteStudent(Student student)
        {
            try
            {
                db.Entry(student).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudent(int studentId)
        {
            try
            {
                var student = GetStudentById(studentId);
                DeleteStudent(student);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }







        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
