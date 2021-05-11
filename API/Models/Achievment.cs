using System.Collections.Generic;

namespace API.Models
{
    public class Achievment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<File> Files { get; set; } = new List<File>();
        public int AchievmentTypeId { get; set; }
        public AchievmentType AchievmentType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Achievment(string Name, int AchievmentTypeId, string Description, int UserId)
        {
            this.Name = Name;
            this.AchievmentTypeId = AchievmentTypeId;
            this.Description = Description;
            this.UserId = UserId;
        }
    }
}