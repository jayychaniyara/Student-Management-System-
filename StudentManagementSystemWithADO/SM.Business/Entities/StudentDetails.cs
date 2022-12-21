using System;
using System.ComponentModel.DataAnnotations;

namespace SM.Business.Entities
{
    public class StudentDetails
    {
        [Key]
        public int StudentID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SchoolName { get; set; }
        public string? Gender { get; set; }

    }
}
