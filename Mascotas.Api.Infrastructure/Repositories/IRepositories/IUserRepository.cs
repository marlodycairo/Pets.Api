using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IUserRepository
    {
        void Login(string user, string pass);
    }
}
