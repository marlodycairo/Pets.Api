using Mascotas.Api.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IOwnerRepository
    {
        Task<ResponseEntity> AddOwner(Owner owner);
        Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(int id);
        Task DeleteOwner(int id);
        Task<ResponseEntity> UpdateOwner(Owner owner);
        Task<ResponseEntity> ReturnMessage(Owner owner);
        Task<ResponseEntity> ReturnMessageUpdateOwner(Owner owner);
    }
}
