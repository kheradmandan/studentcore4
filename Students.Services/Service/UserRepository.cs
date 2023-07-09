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
    public class UserRepository : IUser
    {
        private StudentDbContext db;
        public UserRepository(StudentDbContext _context)
        {
            this.db = _context;
        }
        public void AddUser(User user)
        {
           db.Users.Add(user);
            db.SaveChanges();
        }

        public bool IsExistUserEmail(string email)
        {
            return db.Users.Any(x => x.Email == email);
        }
    }
}
