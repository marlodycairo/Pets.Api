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

        public async Task<ResponseEntityDto> AddPet(PetDto pet)
        {
            var petMapper = mapper.Map<Pet>(pet);

            var returnPetResponse = await petRepository.ReturnMessage(petMapper);

            var petResponse = mapper.Map<ResponseEntityDto>(returnPetResponse);

            return petResponse;
        }

        public async Task DeletePet(int id)
        {
            await petRepository.DeletePet(id);
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

        public async Task<ResponseEntityDto> UpdatePet(int id, PetDto petDto)
        {
            var petMapper = mapper.Map<Pet>(petDto);

            var returnPetResponse = await petRepository.ReturnMessageUpdatePet(id, petMapper);

            var petResponse = mapper.Map<ResponseEntityDto>(returnPetResponse);

            return petResponse;
        }
    }
}
