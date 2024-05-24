using GestaoOvos.Data.Dto;
using GestaoOvos.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoOvos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuarioDto usuarioDto)
        {
            var retorno = await _usuarioService.Login(usuarioDto);

            if (!retorno)
            {
                return NotFound();
            }
            TempData["Message"] = "Bem vindo";
            return RedirectToAction("Index", "Vendas");

        }

        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            await _usuarioService.CadastrarUsuario(usuarioDto);
            return View("Index");

        }

    }
}
