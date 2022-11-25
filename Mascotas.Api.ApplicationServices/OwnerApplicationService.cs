using Mascotas.Api.Application;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mascotas.Api.ApplicationServices
{
    public class OwnerApplicationService : IOwnerApplication
    {
        private readonly IOwnerDomain ownerDomain;

        public OwnerApplicationService(IOwnerDomain ownerDomain)
        {
            this.ownerDomain = ownerDomain;
        }

        public async Task<OwnerDto> AddOwner(OwnerDto owner)
        {
            return await ownerDomain.AddOwner(owner);
        }

        public async Task DeleteOwner(int id)
        {
            await ownerDomain.DeleteOwner(id);
        }

        public Task<IEnumerable<OwnerDto>> GetAllOwner()
        {
            return ownerDomain.GetAllOwner();
        }

        public Task<OwnerDto> GetOwnerById(int id)
        {
            return ownerDomain.GetOwnerById(id);
        }

        public Task<ResponseEntityDto> UpdateOwner(OwnerDto owner)
        {
            return ownerDomain.UpdateOwner(owner);
        }
    }
}
