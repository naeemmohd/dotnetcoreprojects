using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
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
		
		[Route("Home/Privacy")]
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
		public FileResult GetFile()
		{
			//Get the File Path
			string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFFiles\\" + "HOAForm.pdf";
		   
			//Convert to Byte Array
			byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
			var contentDisposition = new ContentDisposition
			{
				FileName = "HOAForm.pdf",
				Inline = true // Set to true if you want to display the file in the browser
			};
			Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
			//Return the Byte Array
			return File(fileBytes, "application/pdf");
		}
		public RedirectResult GoToGoogle()
		{
			return Redirect("https://www.google.com");
		}		
		public RedirectToActionResult ToStudentDetailsAction()
		{
			return RedirectToAction("GetStudentDetails");
		}
		public RedirectToRouteResult ToProvicyRoute()
		{
			return RedirectToRoute("Home/Privacy");
		}
		public IActionResult NotFoundExample()
		{
			// Return a 404 Not Found response
			return new StatusCodeResult(404);
		}
		public IActionResult CustomStatusCodeExample()
		{
			// Return a custom status code
			return new StatusCodeResult(403); 
		}
		public IActionResult BadRequestExample()
        {
            // Return a BadRequestResult
            return new BadRequestResult();
        }
        public IActionResult OKResultExample()
        {
            // Return a OK result
            return new OkResult(); 
        }
	}
}
