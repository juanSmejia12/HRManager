using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class Beneficio
    {
        [Key]
        public int IdBeneficio { get; set; }
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public decimal CostoEmpresa { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal CostoEmpleado { get; set; }
    }
}
