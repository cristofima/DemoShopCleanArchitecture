using System.ComponentModel.DataAnnotations;

namespace Shop.Core.Entities
{
    public class Productos : BaseEntity
    {
        public int Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Unidades { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Marca { get; set; }
    }
}