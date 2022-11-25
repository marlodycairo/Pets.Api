using Mascotas.Api.Application;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
