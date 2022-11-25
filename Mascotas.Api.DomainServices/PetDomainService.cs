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
    public class PetDomainService : IPetDomain
    {
        private readonly IPetRepository petRepository;
        private readonly IMapper mapper;

        public PetDomainService(IPetRepository petRepository, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.mapper = mapper;
        }

        public async Task<PetDto> AddPet(PetDto pet)
        {
            var petMapper = mapper.Map<Pet>(pet);
            
            await petRepository.AddPet(petMapper);

            return pet;
        }

        public async Task DeletePet(int id)
        {
            var petDelete = await petRepository.GetPetById(id);

            mapper.Map<PetDto>(petDelete);
        }

        public async Task<IEnumerable<PetDto>> GetAllPets()
        {
            var pets = await petRepository.GetAllPets();

            var allPets = mapper.Map<IEnumerable<PetDto>>(pets);

            return allPets;
        }

        public async Task<PetDto> GetPetById(int id)
        {
            var petById = await petRepository.GetPetById(id);

            var pet = mapper.Map<PetDto>(petById);

            return pet;
        }

        public async Task<PetDto> UpdatePet(PetDto petDto)
        {
            var pet = mapper.Map<Pet>(petDto);

            await petRepository.UpdatePet(pet);

            return petDto;
        }
    }
}
