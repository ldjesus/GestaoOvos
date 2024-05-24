using AutoMapper;
using GestaoOvos.Data.Dto;
using GestaoOvos.Models;
using GestaoOvos.Services.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace GestaoOvos.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.DataNascimento = Convert.ToDateTime("1986-01-01");
            IdentityResult resultado = await _userManager.CreateAsync(usuario, usuario.PasswordHash);
            if (resultado.Succeeded)
                throw new ApplicationException("Falha ao cadastrar usuário");
        }


        public async Task<bool> Login(LoginUsuarioDto usuarioDto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(usuarioDto.UserName,
                 usuarioDto.PasswordHash, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado");
            }
            return true;
        }

      
    }
}
