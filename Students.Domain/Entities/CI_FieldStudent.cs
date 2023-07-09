using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Domain.Entities
{
    public class CI_FieldStudent
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public ICollection<Student> Students { get; set; } = new Collection<Student>();
    }
}
