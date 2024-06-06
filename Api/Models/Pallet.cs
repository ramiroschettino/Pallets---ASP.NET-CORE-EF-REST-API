using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Pallet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CodProducto { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PesoCarga { get; set; }

        [Required]
        [StringLength(100)]
        public string Ubicacion { get; set; }
    }
}