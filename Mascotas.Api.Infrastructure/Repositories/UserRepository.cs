using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mascotas.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Login(string user, string pass)
        {
            var objUser = (from p in context.Users
                           where p.UserName == user && p.Pass == pass
                           select p).FirstOrDefault();
        }
    }
}
