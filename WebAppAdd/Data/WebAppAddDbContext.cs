using Microsoft.EntityFrameworkCore;
using WebAppAdd.Entities;

namespace WebAppAdd.Data
{
    public class WebAppAddDbContext : IdentityDbContext
    {
        public WebAppAddDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
       
        
    }
}
