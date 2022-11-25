using Mascotas.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IPetRepository
    {
        Task<Pet> AddPet(Pet pet);
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> GetPetById(int id);
        Task DeletePet(int id);
        Task<Pet> UpdatePet(Pet pet);
    }
}
