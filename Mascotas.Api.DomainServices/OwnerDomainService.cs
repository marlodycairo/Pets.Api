using AutoMapper;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.DomainServices
{
    public class OwnerDomainService : IOwnerDomain
    {
        private readonly IOwnerRepository ownerRepository;
        private readonly IMapper mapper;

        public OwnerDomainService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.ownerRepository = ownerRepository;
            this.mapper = mapper;
        }

        public async Task<OwnerDto> AddOwner(OwnerDto owner)
        {
            var ownerMapper = mapper.Map<Owner>(owner);

            await ownerRepository.AddOwner(ownerMapper);

            return owner;
        }
    }
}
