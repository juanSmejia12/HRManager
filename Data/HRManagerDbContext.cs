using HRManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Data
{
    public class HRManagerDbContext : DbContext
    {
    public HRManagerDbContext(DbContextOptions<HRManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<Beneficio> Beneficios { get; set; }
    }
}
