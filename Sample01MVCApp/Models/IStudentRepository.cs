namespace Sample01MVCApp.Models
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
    }
}