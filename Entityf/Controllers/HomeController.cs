using Entityf.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Entityf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["returnedUrl"] = ReturnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
             HttpContext.SignOutAsync();
            return View();
        }

        [HttpPost("Home/Login")]
        public IActionResult Verify(string username,string password, string ReturnUrl)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                // Handle null or empty value
                
               return Redirect(ReturnUrl);
            }

            if (username != "sam" || password != "sam")
            {
                // Handle null or empty values
                return Redirect(ReturnUrl);
            }

            if (username == "sam" && password == "sam")
            { 
                //claim
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, username));

                //claim identity
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
              
                //claim principal
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(ReturnUrl);
            }
            
            return BadRequest();
        }



        [Authorize]
        public IActionResult Secured()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchUser(String searchTerm)
        {
            if (searchTerm == null)
            {
                // If the search term is null, do nothing and return the current view
                return View("AddUsers");
            }

            List<UserModel> users = new List<UserModel>();
            using (var db = new DemoContext())
            {
                users = db.Users.Where(u =>  u.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            TempData["users"] = users;

            return View("AddUsers");
        }

        [Authorize]
        public IActionResult AddUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using (var db = new DemoContext())
            {
                users = db.Users.ToList();
            }
            TempData["users"] = users;

            return View("AddUsers");
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddUsers(UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    user.MyCheckbox = Request.Form["MyCheckbox"].Count > 0;
                    db.Add(user);
                    db.SaveChanges();

                }
                return RedirectToAction("AddUsers");
            }

            List<UserModel> users = new List<UserModel>();
            using (var db = new DemoContext())
            {
                users = db.Users.ToList();
            }
            TempData["users"] = users;
            return View("AddUsers");

        }




        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (var db = new DemoContext())
            {
                // Retrieve the user data from the database based on the provided id
                var user = db.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    // User not found, handle accordingly (e.g., show error message)
                    return NotFound();
                }

                // Remove the user from the database
                db.Users.Remove(user);
                db.SaveChanges();

                // Redirect to a success page or display a success message
                return RedirectToAction("AddUsers");
            }
        }

        public IActionResult Edit(int id)
        {
            using (var db = new DemoContext())
            {
                
                var user = db.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    // User not found
                    return NotFound();
                }

               
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult Update(UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                  
                    var existingUser = db.Users.FirstOrDefault(u => u.Id == user.Id);

                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                   
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    existingUser.UserName = user.UserName;
                    existingUser.MyCheckbox = user.MyCheckbox;
                    existingUser.Gender = user.Gender;
                    existingUser.Role = user.Role;
                    existingUser.DateOfBirth = user.DateOfBirth;
                    existingUser.Age = user.Age;

                    db.Update(user);
                    db.SaveChanges();
                    
                    //db.SaveChanges();

                    return RedirectToAction("AddUsers");
                }
            }

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}