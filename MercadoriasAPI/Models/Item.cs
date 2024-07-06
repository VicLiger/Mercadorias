using System.ComponentModel.DataAnnotations;

namespace MercadoriasAPI.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "A descrição não poder ter mais de 250 caracteres")]
        public string Descrição { get; set; }

        [Required]
        public decimal Preço { get; set; }

        [Required]
        public string Codigo { get; set; }
    }
}
