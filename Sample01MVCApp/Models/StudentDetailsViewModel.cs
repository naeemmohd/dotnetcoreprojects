using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample01MVCApp.Models
{
    public class StudentDetailsViewModel
    {
        public Student? Student { get; set; }
        public Address? Address { get; set; }
        public string? Title { get; set; }
        public string? Header { get; set; }
    }
}