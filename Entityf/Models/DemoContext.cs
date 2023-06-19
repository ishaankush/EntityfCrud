using Microsoft.EntityFrameworkCore;

namespace Entityf.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        
            => options.UseSqlite(@"Data Source=C:\Temp\Demo.db");
        
    }
}
