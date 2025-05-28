using Microsoft.EntityFrameworkCore;
using HRManager.Models;

namespace HRManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
