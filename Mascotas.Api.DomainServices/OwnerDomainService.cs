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

        public async Task DeleteOwner(int id)
        {
            await ownerRepository.DeleteOwner(id);
        }

        public async Task<IEnumerable<OwnerDto>> GetAllOwner()
        {
            var owner = await ownerRepository.GetAllOwners();

            var owners = mapper.Map<IEnumerable<OwnerDto>>(owner);

            return owners;
        }

        public async Task<OwnerDto> GetOwnerById(int id)
        {
            var owner = await ownerRepository.GetOwnerById(id);

            var ownerById = mapper.Map<OwnerDto>(owner);

            return ownerById;
        }

        public async Task<ResponseEntityDto> UpdateOwner(OwnerDto ownerDto)
        {
            var owner = mapper.Map<Owner>(ownerDto);

            var returnOwnerResponse = await ownerRepository.ReturnMessageUpdateOwner(owner);

            var ownerResponse = mapper.Map<ResponseEntityDto>(returnOwnerResponse);

            return ownerResponse;
        }
    }
}
