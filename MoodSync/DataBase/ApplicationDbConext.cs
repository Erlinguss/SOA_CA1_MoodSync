using Microsoft.EntityFrameworkCore;
using MoodSync.Models;

namespace MoodSync.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserCredentialsData> Users { get; set; }
    }
}
