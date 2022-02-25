using coudpermits_test.Models;
using coudpermits_test.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace coudpermits_test.Controllers
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
        public IActionResult login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         [HttpPost]
        public ActionResult Login(ViewModel.LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {

                var isValidUser = IsValidUser(model);

                if (isValidUser != null)
                    return View("Welcome", isValidUser);
                else
                {
                 
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }

        private bool IsValidUser(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}