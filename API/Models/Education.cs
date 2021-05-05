using System;

namespace API.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string EducationName { get; set; }
        public string Degree { get; set; }
        public string Speciality { get; set; }
        public DateTime Graduated { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}