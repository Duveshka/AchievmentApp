using System;

namespace API.Models
{
    public class Education
    {
        public Education(string educationName, string degree, string speciality, DateTime graduated, int userId)
        {
            EducationName = educationName;
            Degree = degree;
            Speciality = speciality;
            Graduated = graduated;
            UserId = userId;
        }

        public int Id { get; set; }
        public string EducationName { get; set; }
        public string Degree { get; set; }
        public string Speciality { get; set; }
        public DateTime Graduated { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}