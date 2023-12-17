using System.ComponentModel.DataAnnotations;

namespace Zummit.Auth.DTO.Request
{
    public class LoginUsuarioRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Senha { get; set; }
    }
}
