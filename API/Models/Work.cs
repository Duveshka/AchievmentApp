using System;

namespace API.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Speciality { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}