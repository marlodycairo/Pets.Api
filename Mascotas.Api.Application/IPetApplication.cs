using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Application
{
    public interface IPetApplication
    {
        Task<ResponseEntityDto> AddPet(PetDto pet);
        Task<IEnumerable<PetDto>> GetAllPets();
        Task<PetDto> GetPetById(int id);
        Task DeletePet(int id);
        Task<ResponseEntityDto> UpdatePet(int id, PetDto pet);
    }
}
