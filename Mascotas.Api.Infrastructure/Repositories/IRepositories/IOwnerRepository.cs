using Mascotas.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IOwnerRepository
    {
        Task<Owner> AddOwner(Owner owner);
    }
}
