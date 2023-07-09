using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface ICourseStudent: IDisposable
    {
        IEnumerable<CourseStudent> GetAllCourseStudents();
        CourseStudent GetCourseStudentById(int courseId, int StudentId);
        bool InsertCourseStudent(CourseStudent courseStudent);
        bool UpdateCourseStudent(CourseStudent courseStudent);
        bool DeleteCourseStudent(CourseStudent courseStudent);
        bool DeleteCourseStudent(int courseId, int StudentId);
        void Save();
    }
}
