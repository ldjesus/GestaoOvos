using System;

namespace GestaoOvos.Services.Exception
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException( string message) : base(message)
        {

        }    
    }
}
