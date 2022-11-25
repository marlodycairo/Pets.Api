using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Mascotas.Api.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly ApplicationDbContext context;

        public RolRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<string> GetRolsByUsers(int userId)
        {
            return (from p in context.UserRols
                    join rol in context.Rols
                    on p.RolId equals rol.Id
                    where p.UserId == userId
                    select rol.RolName).ToList();
        }
    }
}
