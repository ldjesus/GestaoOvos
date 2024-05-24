using Microsoft.AspNetCore.Identity;
using System;
using System.Data;

namespace GestaoOvos.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }      

        public Usuario() : base() { }
    }
}
