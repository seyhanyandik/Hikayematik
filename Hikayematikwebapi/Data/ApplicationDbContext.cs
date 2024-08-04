using Hikayematikwebapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Hikayematikwebapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
            options):base(options)
        {
        }
        public DbSet<Siir> siir { get; set; }
    }
}
