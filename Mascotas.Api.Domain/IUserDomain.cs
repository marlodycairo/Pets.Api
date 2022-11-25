using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain
{
    public interface IUserDomain
    {
        void Login(string user, string pass);
    }
}
