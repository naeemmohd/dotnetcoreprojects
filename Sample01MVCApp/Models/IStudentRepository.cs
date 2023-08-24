using System.Collections.Generic;

namespace Sample01MVCApp.Models
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
        List<Student> GetAllStudents();
    }
}