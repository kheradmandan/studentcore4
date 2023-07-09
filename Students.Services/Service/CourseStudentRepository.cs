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
    public class CourseStudentRepository 
        //: ICourseStudent
    {
        private StudentDbContext db;
        public CourseStudentRepository(StudentDbContext _context)
        {
            this.db = _context;
        }

        public IEnumerable<CourseStudent> GetAllCourseStudents()
        {
            return db.CourseStudents;
        }

       // public CourseStudent GetCourseStudentById(int courseId, int StudentId)
       // {
          //  return db.CourseStudents.Where(p => p.CourseId == courseId && p.StudentId == StudentId).ToList().First();
        //}

        public bool InsertCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                db.CourseStudents.Add(courseStudent);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                db.Entry(courseStudent).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                db.Entry(courseStudent).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //public bool DeleteCourseStudent(int courseId, int StudentId)
        //{
        //    try
        //    {
        //        var coursstudent = GetCourseStudentById(courseId, StudentId);
        //        DeleteCourseStudent(coursstudent);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        public void Dispose()
        {
            db.Dispose();
        }

       

        public void Save()
        {
         
            db.SaveChanges();
        }

   
    }
}
