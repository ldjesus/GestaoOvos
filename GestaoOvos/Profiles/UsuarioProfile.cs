using AutoMapper;
using GestaoOvos.Data.Dto;
using GestaoOvos.Models;

namespace GestaoOvos.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
