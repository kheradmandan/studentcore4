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
  
    public class Student

    {
      
        [Key]
        public int Id { get; set; }
        //  public int CourseStudentId { get; set; }

        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; } = default!;

        [Display(Name = "سن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Age { get; set; }

        [Display(Name = "کد ملی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(10)]
        [StringLength(10)]
        [ValidationNationalCode]
        public string NationalCode { get; set; } =default!;
     
        ////////////////////////
        public int CI_FieldStudentId { get; set; }
       // public virtual CI_FieldStudent CI_FieldStudent { get; set; } = new CI_FieldStudent();
        ////////////////////
        public virtual ICollection<CourseStudent> CourseStudent { get; set; } = new Collection<CourseStudent>();


    }
}
