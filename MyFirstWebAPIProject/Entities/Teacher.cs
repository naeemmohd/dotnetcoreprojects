namespace MyFirstWebAPIProject.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? StandardId { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual Standard? Standard { get; set; }
    }
}