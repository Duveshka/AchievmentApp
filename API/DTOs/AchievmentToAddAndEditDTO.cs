using System.Collections.Generic;

namespace API.DTOs
{
    public class AchievmentToAddAndEditDTO
    {
        public string Name { get; set; }
        public AchievmentTypeDTO AchievmentType { get; set; }
        public string Description { get; set; }
        public ICollection<FileDTO> Files { get; set; }
    }
}