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
    public class TeacherRepository : ITeacher
    {

        private StudentDbContext db;
        public TeacherRepository(StudentDbContext _context)
        {
            this.db = _context;
        }
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return db.Teachers;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return db.Teachers.Find(teacherId);
        }

        public bool InsertTeacher(Teacher teacher)
        {
            try
            {
                db.Teachers.Add(teacher);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            try
            {
                db.Entry(teacher).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteTeacher(Teacher teacher)
        {
            try
            {
                db.Entry(teacher).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTeacher(int teacherId)
        {
            try
            {
                var teacher = GetTeacherById(teacherId);
                DeleteTeacher(teacher);

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
