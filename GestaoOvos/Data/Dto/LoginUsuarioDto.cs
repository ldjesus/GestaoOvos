using GestaoOvos.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace GestaoOvos.Data.Dto
{
    public class LoginUsuarioDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
