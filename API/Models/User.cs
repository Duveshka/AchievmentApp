using System;
using System.Collections.Generic;

namespace API.Models
{
    public enum Sex
        {
            Female,
            Male
        }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public bool IsParent { get; set; }
        public Sex Sex { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } 
        public string About { get; set; }
        

        public ICollection<Education> Educations { get; set; }
        public ICollection<Achievment> Achievments { get; set; }
        public ICollection<Work> Works { get; set; }
        public City City { get; set; }
        
        public User(string Login, byte[] PasswordHash, byte[] PasswordSalt)
        {
            this.Login = Login;
            this.PasswordHash = PasswordHash;
            this.PasswordSalt = PasswordSalt;
        }
    }
}