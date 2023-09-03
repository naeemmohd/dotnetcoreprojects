using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPIProject.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class TestController : ControllerBase
	{
		[HttpGet]
		[Route("Get1")]
		public string GetFrom1() {
			return "Returning from TestController Get1 Method";
		}		[HttpGet(Name = "GetTest1")]

		[HttpGet]
		[Route("Get2")]
		public string GetFrom2() {
			return "Returning from TestController Get2 Method";
		}
	}
}