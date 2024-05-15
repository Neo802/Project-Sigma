/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using System.Security.Cryptography;

namespace ProjectRunAway.Controllers
{
    public class UsersController : Controller
    {
        private readonly TableContext _context;

        public UsersController(TableContext context)
        {
            _context = context;
        }

        private bool VerifyPassword(Users user, string password)
        {
            // Placeholder for password verification logic
            // In a real application, you would hash the incoming password and compare it with the stored hash
            return user.Password == HashPassword(password); // Simplistic hash check
        }

        private string HashPassword(string password)
        {
            // Hashing password, using a simple method for demonstration
            // You should use a secure hashing method like BCrypt or PBKDF2 in production
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private void SignInUser(Users user, bool rememberMe)
        {
            // Logic to create authentication cookie or session
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("FullName", user.Username), // Example additional claim
                new Claim(ClaimTypes.Role, "User"), // Example role claim
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(rememberMe ? 1440 : 60), // 24 hours or 1 hour
                IsPersistent = rememberMe,
            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }


        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersId,Username,Password,Personal_question,Personal_answer,Address")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersId,Username,Password,Personal_question,Personal_answer,Address")] Users users)
        {
            if (id != users.UsersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UsersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UsersId == id);
        }

        public IActionResult Login()
        {
            return View(); // Returns the Login.cshtml view
        }

        public IActionResult ResetPassword()
        {
            return View(); // Returns the ResetPassword.cshtml view
        }

        public IActionResult CreateAccount()
        {
            return View(); // Returns the CreateAccount.cshtml view
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, bool rememberMe)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null && user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
            {
                return View("Login", new { Error = "Account is currently locked." });
            }

            if (user == null || !VerifyPassword(user, password))
            {
                if (user != null)
                {
                    user.FailedAttemptCount++;
                    if (user.FailedAttemptCount >= 10)
                    {
                        user.LockoutEnd = DateTime.Now.AddMinutes(30); // lock the account for 30 minutes
                    }
                    await _context.SaveChangesAsync();
                }
                return View("Login", new { Error = "Invalid username or password." });
            }

            user.FailedAttemptCount = 0;
            user.LockoutEnd = null;
            await _context.SaveChangesAsync();
            SignInUser(user, rememberMe);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string username, string personalQuestionAnswer, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || user.PersonalAnswer != personalQuestionAnswer)
            {
                return View("ResetPassword", new { Error = "Invalid username or security answer." });
            }

            user.Password = HashPassword(newPassword); // Ensure to hash the password before saving
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }


    }
}
*/