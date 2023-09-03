namespace MyFirstWebAPIProject.Entities
{
    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public int StudentId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}