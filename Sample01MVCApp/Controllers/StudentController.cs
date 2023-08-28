using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample01MVCApp.Models;

namespace Sample01MVCApp.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentRepository _studentRepository;
		public StudentController(IStudentRepository studentRepository)
		{
			_studentRepository=studentRepository;
		}

		[Route("Student/ById")]
		public IActionResult Index(int Id=101)
		{
			Student student = _studentRepository.GetStudentById(Id);
			return View(student);
		}

		[Route("Student/ByJSONId/{Id=101}")]
		public JsonResult GetStudentById(int Id)
		{
			return Json(_studentRepository.GetStudentById(Id));
		}

		[Route("Student/All")]
		public JsonResult GetAllStudents()
		{
			var students = _studentRepository.GetAllStudents();
			var options = new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			};
			return Json(students, options);
		}

		[Route("Student/ByName/name=naeem")]
		public string GetStudentsByName(string name)
		{
			return $"Return All Students with Name : {name}";
		}   
		public ViewResult DetailsViewData()
		{
			ViewData["Title"]= "Student Details Page";
			ViewData["Header"]= "Student Details using ViewData as Dictionary";

			var student =new  Student(){
				StudentId = 101,
				Name = "James",
				Branch = "CSE",
				Section = "A",
				Gender = "Male"
			};
			ViewData["Student"]= student;

			return View();

		}
		public ViewResult DetailsViewBag()
		{
			ViewBag.Title = "Student Details Page";
			ViewBag.Header = "Student Details using ViewBag as dynamic property/variable";
			Student student = new Student()
			{
				StudentId = 101,
				Name = "James",
				Branch = "CSE",
				Section = "A",
				Gender = "Male"
			};
			ViewBag.Student = student;
			return View();

		}

		public ViewResult Details()
		{
			ViewBag.Title = "Student Details Page";
			ViewBag.Header = "Student Details using Strongly typed model";
			Student student = new Student()
			{
				StudentId = 101,
				Name = "James",
				Branch = "CSE",
				Section = "A",
				Gender = "Male"
			};
			
			return View(student);

		}
		public ViewResult DetailsViewModel()
		{
			Student student = new Student()
			{
				StudentId = 101,
				Name = "Dillip",
				Branch = "CSE",
				Section = "A",
				Gender = "Male"
			};
			//Student Address
			Address address = new Address()
			{
				StudentId = 101,
				City = "Mumbai",
				State = "Maharashtra",
				Country = "India",
				Pin = "400097"
			};
			
			StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel(){
				Student = student,
				Address = address,
				Header="Student Details",
				Title = "Student Details Page"

			};
			return View(studentDetailsViewModel);

		}
		//URL Pattern: /Student/1/Courses
		[Route("Student/{studentID=101}/Courses")] 
		public JsonResult GetStudentCourses(int studentID)
		{
			//Real-Time you will get the courses from database, here we have hardcoded the data
			List<string> CourseList = new List<string>();
			if (studentID == 101)
				CourseList = new List<string>() { "ASP.NET Core", "C#.NET", "SQL Server" };
			else if (studentID == 102)
				CourseList = new List<string>() { "ASP.NET Core MVC", "C#.NET", "ADO.NET Core" };
			else if (studentID == 103)
				CourseList = new List<string>() { "ASP.NET Core WEB API", "C#.NET", "Entity Framework Core" };
			else
				CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
			
			return Json(CourseList);
		}
	}
}