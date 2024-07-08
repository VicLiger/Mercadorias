using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.Domain.Entities
{
    public sealed class Item
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "A descrição não poder ter mais de 250 caracteres")]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string Codigo { get; set; }
    }
}
