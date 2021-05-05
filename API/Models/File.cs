namespace API.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }

        public int AchievmentId { get; set; }
        public Achievment Achievment { get; set; }
    }
}