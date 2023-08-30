using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPIProject.Controllers
{
	[ApiController]
	//token replacement using [controller]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		[HttpGet]
		[Route("All")]
		public string GetEmployeeAll()
		{
			return "Response from GetEmployeeAll Method";
		}
		
		//token replacement using {id} with routing constraint
		[HttpGet]
		[Route("GetById/{id:int}")]
		public string GetEmployeeById(int id)
		{
			return $"Response from GetEmployeeById Method, Id is : {id}";
		}
		
		//token replacement using {id} and {name} with routing constraint
		[HttpGet]
		[Route("GetByIdAndName/{id:int}/{name:alpha}")]
		public string GetEmployeeByIdAndName(int id, string name)
		{
			return $"Response from GetEmployeeByIdAndName Method Id is: {id} and name is: {name}";
		}
		
		//token replacement using {id} and {name}
		[HttpGet]
		[Route("GetByIdAndName/Id/{id}/Name/{name}")]
		public string GetEmployeeByIdAndNameinURL(int id, string name)
		{
			return $"Response from GetEmployeeByIdAndNameinURL Method Id is: {id} and name is: {name}";
		}
		
		[HttpGet]
		[Route("GetByIdAndCity")]
		//use of querystring
		public string GetEmployeeByIdAndCity(int id, string city)
		{
			return $"Response from GetEmployeeById Method Id is: {id} and name is: {city}";
		}
	}
}