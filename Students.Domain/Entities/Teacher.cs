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
    public class Teacher
    {
        [Key]
        public int Id { get; set; }



        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; } = "";
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        //  [RegularExpression("\"^(?:0|98|\\+98|\\+980|0098|098|00980)?(9\\d{9})$\"" ,ErrorMessage ="فرمت شماره همراه باید درست باشد")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$" ,ErrorMessage ="لطفا درست وارد کنید ") ]
        public string Mob { get; set; } = "";



        public  ICollection<Course> Courses { get; set; } = new Collection<Course>();
    }
}
