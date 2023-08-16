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
    }
}