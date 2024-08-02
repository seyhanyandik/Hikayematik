using Hikayematik.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hikayematik.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Biyografi>? biyografi { get; set; }

        public DbSet<Drama>? drama { get; set; }

        public DbSet<Hikaye>? hikaye { get; set; }

        public DbSet<Masal>? masal { get; set; }

        public DbSet<Reklam>? reklam { get; set; }

        public DbSet<Siir>? siir { get; set; }

        public DbSet<Ani_sohbet>? ani_sohbet { get; set; }

        public DbSet<Deyim_hikaye>? deyim_hikaye { get; set; }

        public DbSet<Pratik_Bilgiler>? pratik_bilgiler { get; set; }

        public DbSet<Tarihi_Yerler>? tarihi_yerler { get; set; }


    }
}
