using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyFirstWebAPIProject.Entities
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EFCoreDbContext _context;
        
        public StudentRepository(EFCoreDbContext context){
            _context = context;

        }
        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }
    }
}