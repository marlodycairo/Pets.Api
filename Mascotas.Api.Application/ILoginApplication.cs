using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Application
{
    public interface ILoginApplication
    {
        string GenerateJsonWebToken(LoginDto loginDto);
        LoginDto AuthenticateUser(LoginDto login);
    }
}
