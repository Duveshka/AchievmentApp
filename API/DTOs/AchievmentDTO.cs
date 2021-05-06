using System.Collections.Generic;
using API.Models;

namespace API.DTOs
{
    public class AchievmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AchievmentType AchievmentType { get; set; }
        public string Description { get; set; }
        public List<File> Files { get; set; }
    }
}