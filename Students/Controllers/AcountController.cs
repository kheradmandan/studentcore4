using Microsoft.AspNetCore.Mvc;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

namespace Students.Controllers
{
    public class AcountController : Controller
    {
        private readonly StudentDbContext _context;
        private IUser userRepository;
        public AcountController(StudentDbContext context)
        {
            _context = context;
            userRepository = new UserRepository(_context);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User  user)
        {
            if (ModelState.IsValid) { 
                return View(user);  
            }
            if (userRepository.IsExistUserEmail(user.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "قبلا ثبت نام شده است ");
                return View(user);
            }
            user.Email=user.Email.ToLower();    
            userRepository.AddUser(user);   
            return View();
        }
    }
}
