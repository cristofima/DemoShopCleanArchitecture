using System.ComponentModel.DataAnnotations;

namespace Shop.Core.Entities
{
    public class Productos : BaseEntity
    {
        public int Codigo { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(15)]
        public string Unidades { get; set; }

        [Required]
        [Range(0, 150)]
        public int Stock { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Marca { get; set; }
    }
}