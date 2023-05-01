using Books_Library.Data;
using Books_Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;


namespace Books_Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult User()
        {
            var users = _dbContext.Users.AsEnumerable();
            return View(users);
        }
        public IActionResult Profile(int id)
        {
            var profileViewModel = new UserBooksViewModel();
            profileViewModel.User = _dbContext.Users.Where(c => c.Id == id).FirstOrDefault();
            var borrowings = _dbContext.UserBorrowings
                .Where(c => c.Id == profileViewModel.User.Id)
                .Select(c => c.BookId)
                .ToList();
            profileViewModel.Books = _dbContext.Books
                .Where(b => borrowings.Contains(b.Id)).ToList();
            return View(profileViewModel);
            //return View(_dbContext.Users.Where(c => c.Id == id).FirstOrDefault());
        }
        public IActionResult AddOrEdit(int? id)
        {
            return View(_dbContext.Users.Where(c => c.Id == id).FirstOrDefault());
        }
        public async Task<IActionResult> AddOrEdited(User user)
        {
            if (user.Id == 0)
            {
                _dbContext.Users.Add(user);
            }
            else
            {
                _dbContext.Update(user);
            }
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(User));
        }
        public async Task<IActionResult> DeletedUser(int? id)
        {
            _dbContext.Remove(_dbContext.Users.Where(c => c.Id == id).FirstOrDefault());
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(User));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}