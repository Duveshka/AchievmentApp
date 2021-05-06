using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public bool IsParent { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } 
        public string About { get; set; }
        

        public ICollection<EducationDTO> Educations { get; set; }
        public ICollection<AchievmentDTO> Achievments { get; set; }
        public ICollection<WorkDTO> Works { get; set; }
        public CityDTO City { get; set; }
    }
}