using System.ComponentModel.DataAnnotations;

namespace Zummit.Auth.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string? Nome { get; set; }
    }
}
