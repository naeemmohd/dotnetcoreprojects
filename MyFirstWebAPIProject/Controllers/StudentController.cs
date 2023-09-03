using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Entities;

namespace MyFirstWebAPIProject.Controllers
{
	[ApiController]
	[Route("api")]
	public class StudentController : ControllerBase
	{
		private readonly IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
			_repository = repository;
        }

        //multiple routes for same end point
        [HttpGet]
		[Route("AllStudents")]
		[Route("Student/All")]
		public ActionResult<List<Student>> GetAllStudents()
		{
			return _repository.GetStudents();
		} 
		
		[HttpGet]
		[Route("StudentsById")]
		//token replacement using {id} with routing constraint with range
		[Route("Student/ById/{id:int:range(1,100)}")]
		//token replacement using {id} with routing constraint with min max
		//[Route("Student/ById/{id:int:min(100):max(1000)}")]
		public ActionResult<Student?> GetStudentsById(int id)
		{
			return _repository.GetStudentById(id);
		}
	}
}