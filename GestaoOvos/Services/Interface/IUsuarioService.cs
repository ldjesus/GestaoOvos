using GestaoOvos.Data.Dto;
using System.Threading.Tasks;

namespace GestaoOvos.Services.Interface
{
    public interface IUsuarioService
    {
        Task CadastrarUsuario(CreateUsuarioDto usuarioDto);
        Task<bool> Login(LoginUsuarioDto usuarioDto);
    }
}
