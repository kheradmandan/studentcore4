using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class CourseStudent
    {
        [Key]
        public int Id { get; set; }
        public  int CourseId { get; set; }
        public int StudentId { get; set; }
        public virtual Course courses { get; set; } = new Course(); 
        public  virtual Student Students { get; set; } = new Student();
    }
}
