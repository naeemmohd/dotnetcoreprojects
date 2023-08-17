using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Index(int Id)
        {
            Student student = _studentRepository.GetStudentById(Id);
            return View(student);
        }
        public string GetAllStudents()
        {
            return "Return All Students";
        }
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
    }
}