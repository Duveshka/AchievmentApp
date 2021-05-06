using System.Collections.Generic;

namespace API.Models
{
    public class Achievment
    {
        public Achievment(string name, AchievmentType achievmentType, string description, ICollection<File> files, int userId)
        {
            Name = name;
            AchievmentType = achievmentType;
            Description = description;
            Files = files;
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public AchievmentType AchievmentType { get; set; }
        public string Description { get; set; }
        public ICollection<File> Files { get; set; } = new List<File>();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}