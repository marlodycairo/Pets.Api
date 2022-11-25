using Mascotas.Api.Application;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
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

        public async Task<PetDto> AddPet(PetDto pet)
        {
            return await petDomain.AddPet(pet);
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

        public async Task<PetDto> UpdatePet(PetDto pet)
        {
            return await petDomain.UpdatePet(pet);
        }
    }
}
