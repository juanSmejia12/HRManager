using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class Nomina
    {
        [Key]
        public int IdNomina { get; set; }

        [Required]
        public int IdEmpleado_fk { get; set; }
        [Required]
        public string PeriodoInicio { get; set; }
        [Required]
        public string PeriodoFin { get; set; }
        public float TotalPagado { get; set; }

    }
}
