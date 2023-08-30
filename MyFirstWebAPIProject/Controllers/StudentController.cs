using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPIProject.Controllers
{
	[ApiController]
	[Route("api")]
	public class StudentController : ControllerBase
	{
		//multiple routes for same end point
		[HttpGet]
		[Route("AllStudents")]
		[Route("Student/All")]
		public string GetAllStudents()
		{
			return "Response from GetAllStudents Method";
		} 
		
		[HttpGet]
		[Route("StudentsById")]
		//token replacement using {id} with routing constraint with range
		[Route("Student/ById/{id:int:range(100,1000)}")]
		//token replacement using {id} with routing constraint with min max
		//[Route("Student/ById/{id:int:min(100):max(1000)}")]
		public string GetStudentsById(int id)
		{
			return $"Response from GetStudentsById Method, Id is : {id}";
		}
	}
}