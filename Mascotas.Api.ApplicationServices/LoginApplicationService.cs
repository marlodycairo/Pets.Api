using Mascotas.Api.Application;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.ApplicationServices
{
    public class LoginApplicationService : ILoginApplication
    {
        private readonly ILoginDomain loginDomain;

        public LoginApplicationService(ILoginDomain loginDomain)
        {
            this.loginDomain = loginDomain;
        }

        public LoginDto AuthenticateUser(LoginDto login)
        {
            return loginDomain.AuthenticateUser(login);
        }

        public string GenerateJsonWebToken(LoginDto loginDto)
        {
            return loginDomain.GenerateJsonWebToken(loginDto);
        }
    }
}
