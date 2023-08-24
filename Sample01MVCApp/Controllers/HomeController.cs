using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample01MVCApp.Models;

namespace Sample01MVCApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        public IActionResult Index()
        {
            TempData["AppName"]= "Training App";
            TempData.Keep();
            return View();
        }

        [Route("/{Id?}")]
        public IActionResult Index(int Id)
        {
            TempData["AppName"]= "Training App " + Id;
            TempData.Keep();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetStudentDetails(int Id)
        {
            StudentRepository repository = new StudentRepository();
            Student student = repository.GetStudentById(Id);

            return Json(student);
        }
    }
}
