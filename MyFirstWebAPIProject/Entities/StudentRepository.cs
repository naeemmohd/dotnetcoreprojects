using Microsoft.EntityFrameworkCore;

namespace MyFirstWebAPIProject.Entities
{

    //Note : // Using Eager loading for related entities
    public class StudentRepository : IStudentRepository
    {
        private readonly EFCoreDbContext _context;
        
        public StudentRepository(EFCoreDbContext context){
            _context = context;

        }
        public Student? GetStudentById(int id)
        {
            //use of Lazy Loading 
            //1. Loading student ddata only at first
            var student = _context.Students.Find(id);
            //2. Loading related data now 
            // it will execute Separate SQL query)
            //StudentAddress? studentAddress = student?.StudentAddress;
            //Console.WriteLine($"AddresLin1 {studentAddress?.Address1}, AddresLin2 {studentAddress?.Address2}");
            //Standard? standard = student?.Standard;
            //Console.WriteLine($"StandardName: {standard?.StandardName}, Description: {standard?.Description}");

            return student;
        }

        public List<Student> GetStudents()
        {
            //use of Eager Loading
            //FormattableString sql = $"Select * from Students";
            return _context.Students
                // Eager loading related entities
                //.FromSql(sql)
                .Include(std => std.Standard)
                .Include(addr => addr.StudentAddress)
                .Include(crs => crs.Courses)
                .ToList();
        }
    }
}