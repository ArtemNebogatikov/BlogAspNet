using BlogAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogAspNet.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;


        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();

            Console.WriteLine("See all blog authors:");
            foreach (var author in authors)
                Console.WriteLine($"Author name {author.FirstName}, joined {author.JoinDate}");

            return View(authors);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
