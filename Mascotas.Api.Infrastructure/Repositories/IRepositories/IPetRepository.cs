using Mascotas.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IPetRepository
    {
        Task<ResponseEntity> AddPet(Pet pet);
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> GetPetById(int id);
        Task DeletePet(int id);
        Task<ResponseEntity> UpdatePet(int id, Pet pet);
        Task<ResponseEntity> ReturnMessage(Pet pet);
        Task<ResponseEntity> ReturnMessageUpdatePet(int id, Pet pet);
    }
}
