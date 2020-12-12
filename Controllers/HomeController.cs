using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCCoreAngular.Data;
using MVCCoreAngular.Models;
using MVCCoreAngular.Services;
using MVCCoreAngular.ViewModels;
using System.Diagnostics;

namespace MVCCoreAngular.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailServices _mailService;
        private readonly IRepository repository;

        public HomeController(IMailServices mailService, IRepository repository)
        {
            _mailService = mailService;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        [Authorize]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("ommalor@gmail.com", model.Subject, $"From: {model.Name} - {model.Email} Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            var results = repository.GetAllProducts();
            return View(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
