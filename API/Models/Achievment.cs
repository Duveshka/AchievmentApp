using System.Collections.Generic;

namespace API.Models
{
    public class Achievment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AchievmentType AchievmentType { get; set; }
        public string Description { get; set; }
        public ICollection<File> Files { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}