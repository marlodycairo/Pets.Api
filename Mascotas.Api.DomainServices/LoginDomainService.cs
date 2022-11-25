using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Mascotas.Api.DomainServices
{
    public class LoginDomainService : ILoginDomain
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;
        private readonly IRolRepository rolRepository;

        public LoginDomainService(ApplicationDbContext context, IConfiguration configuration, IRolRepository rolRepository)
        {
            this.context = context;
            this.configuration = configuration;
            this.rolRepository = rolRepository;
        }

        public LoginDto AuthenticateUser(LoginDto loginDto)
        {
            LoginDto user = null;

            IEnumerable<User> users;

            users = from p in context.Users
                    where p.UserName == loginDto.User
                    select p;

            if (loginDto.User == users.First().UserName)
            {
                user = new LoginDto
                {
                    User = users.First().UserName,
                    Pass = users.First().Pass
                };
            }

            return user;
        }

        public string GenerateJsonWebToken(LoginDto loginDto)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            User user = context.Users.FirstOrDefault(p => p.UserName == loginDto.User);

            List<string> rols = rolRepository.GetRolsByUsers(user.Id);

            Claim[] claims = new Claim[] { };

            foreach (string rol in rols)
            {
                claims = new Claim[]
                {
                    new Claim(ClaimTypes.Role, rol),
                    new Claim(ClaimTypes.Email, loginDto.User),
                    new Claim(JwtRegisteredClaimNames.Iss, "https://localhost:44368/login/"),
                    new Claim(JwtRegisteredClaimNames.Sub, loginDto.User),
                    new Claim(JwtRegisteredClaimNames.Email, loginDto.User),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            }

            JwtSecurityToken token = new JwtSecurityToken(configuration["Jwt.Issuer"], configuration["Jwt:Issuer"], claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
