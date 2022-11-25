using Mascotas.Api.Application;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.ApplicationServices
{
    public class PetApplicationService : IPetApplication
    {
        private readonly IPetDomain petDomain;

        public PetApplicationService(IPetDomain petDomain)
        {
            this.petDomain = petDomain;
        }

        public async Task<ResponseEntityDto> AddPet(PetDto petDto)
        {            
            return await petDomain.AddPet(petDto);
        }

        public async Task DeletePet(int id)
        {
            await petDomain.DeletePet(id);
        }

        public async Task<IEnumerable<PetDto>> GetAllPets()
        {
            return await petDomain.GetAllPets();
        }

        public async Task<PetDto> GetPetById(int id)
        {
            return await petDomain.GetPetById(id);
        }

        public async Task<ResponseEntityDto> UpdatePet(int id, PetDto pet)
        {
            return await petDomain.UpdatePet(id, pet);
        }
    }
}
