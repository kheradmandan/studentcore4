using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Repositories
{
    public interface IUser
    {
        bool IsExistUserEmail(string email);    
        public void AddUser(User user);

    }
}
