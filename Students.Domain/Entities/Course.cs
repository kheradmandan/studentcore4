using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Students.Domain.Entities
{
    public class Course
    {
      
     
        [Key]
        public int Id { get; set; }
       
        //   public int CourseStudentId { get; set; }

        [Display(Name = "اسم کلاس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Title { get; set; } = default!;

        [Display(Name = "زمان برگزاری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(8,17)]
        public int Classtime { get; set; }= default!;

        [Display(Name = "زمان هر جلسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TimeOfSession { get; set; }

        public int TeacherId { get; set; }
      //  public Teacher ClassTeacher { get; set; } = new Teacher();
 
     //   public  ICollection<Student> Students { get; set; } = default!;
        ////////////////////////
        public int CI_FieldCourseId { get; set; }
       // public CI_FieldCourse CI_FieldCourse { get; set; } = new CI_FieldCourse();
        //////////////////////
        public  virtual ICollection<CourseStudent> CourseStudent { get; set; } = new Collection<CourseStudent>();


    }
}
