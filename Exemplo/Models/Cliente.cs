using System.ComponentModel.DataAnnotations;

namespace Exemplo.WebApp.Models
{
    public class Cliente
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
