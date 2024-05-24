using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoOvos.Data.Dto
{
    public class CreateUsuarioDto
    {
      
        [Required]       
        public string Nome { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [Required]
        [Compare("PasswordHash")]
        public string CompararPasswordHash { get; set; }

    }
}

