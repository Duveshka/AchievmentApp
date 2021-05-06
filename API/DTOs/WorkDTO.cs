using System;

namespace API.DTOs
{
    public class WorkDTO
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Speciality { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Description { get; set; }

    }
}