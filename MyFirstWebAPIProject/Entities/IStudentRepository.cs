namespace MyFirstWebAPIProject.Entities
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student? GetStudentById(int id);
    }
}