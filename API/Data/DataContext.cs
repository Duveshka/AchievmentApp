using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<User> User { get; set; }
        public DbSet<Achievment> Achievment { get; set; }
        public DbSet<AchievmentType> AchievmentType { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Work> Work { get; set; }
    }
}