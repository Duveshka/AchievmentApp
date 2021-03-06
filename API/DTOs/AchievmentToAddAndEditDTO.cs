using System.Collections.Generic;
using API.Models;

namespace API.DTOs
{
    public class AchievmentToAddAndEditDTO
    {
        public string Name { get; set; }
        public int AchievmentTypeId { get; set; }
        public string Description { get; set; }
        public ICollection<File> Files { get; set; }
    }
}