using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Domain
{
    public interface IOwnerDomain
    {
        Task<OwnerDto> AddOwner(OwnerDto owner);
        Task<IEnumerable<OwnerDto>> GetAllOwner();
        Task<OwnerDto> GetOwnerById(int id);
        Task DeleteOwner(int id);
        Task<ResponseEntityDto> UpdateOwner(OwnerDto owner);
    }
}
