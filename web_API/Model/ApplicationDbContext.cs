using Microsoft.EntityFrameworkCore;

namespace web_API.Model
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<IplPlayer> iplPlayer { get; set; }
        public string connectionString;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 


        }
    }
   
}
