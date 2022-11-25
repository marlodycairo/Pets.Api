using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain
{
    public interface ILoginDomain
    {
        string GenerateJsonWebToken(LoginDto loginDto);
        LoginDto AuthenticateUser(LoginDto loginDto);
    }
}
