using Mascotas.Api.Domain;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.DomainServices
{
    public class UserDomainService : IUserDomain
    {
        private readonly IUserRepository userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Login(string user, string pass)
        {
            userRepository.Login(user, pass);
        }
    }
}
