using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IRolRepository
    {
        List<string> GetRolsByUsers(int userId);
    }
}
