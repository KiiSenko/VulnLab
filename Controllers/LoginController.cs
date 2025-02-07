using Microsoft.AspNetCore.Mvc;
using MyVulnerableApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;  // Usa SqliteParameter da Microsoft.Data.Sqlite

namespace MyVulnerableApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        // Inietta il contesto nel controller
        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // Azione per visualizzare la pagina di login
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(string username, string password, bool isInjectionProtectionEnabled)
        {
                // Ad esempio, usa Debug.WriteLine o Console.WriteLine (se vedi i log nel debugger)
                Console.WriteLine($"SQL Injection Protection is enabled: {isInjectionProtectionEnabled}");

                if (isInjectionProtectionEnabled)
                {
                    // Query sicura
                    var query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
                    var user = _context.Users
                    .FromSqlRaw(query, 
                    new SqliteParameter("@username", username), 
                    new SqliteParameter("@password", password))
                    .FirstOrDefault();

                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Query vulnerabile
                var query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
                var user = _context.Users.FromSqlRaw(query).FirstOrDefault();

                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Message = "Invalid username or password.";
            return View("Index");
        }   

    }
}




