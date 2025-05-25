using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class Nomina
    {
        [Key]
        public int IdNomina { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalPagado { get; set; }

        public Empleado Empleado { get; set; }
    }
}
