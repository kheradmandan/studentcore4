using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class CI_FieldCourse
    {
      
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public ICollection<Course> Courses { get; set; }= new Collection<Course>();

    }
}
