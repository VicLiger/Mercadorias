using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MercadoriasAPI.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Descrição { get; set; }

        [Required]
        public decimal Preço { get; set; }

        [Required]
        public string codigo { get; set; }
    }
}
