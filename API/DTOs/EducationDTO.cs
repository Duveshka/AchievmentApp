using System;

namespace API.DTOs
{
    public class EducationDTO
    {
        public int Id { get; set; }
        public string EducationName { get; set; }
        public string Degree { get; set; }
        public string Speciality { get; set; }
        public DateTime Graduated { get; set; }
    }
}