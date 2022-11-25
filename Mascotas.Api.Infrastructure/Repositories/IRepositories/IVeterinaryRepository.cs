using Mascotas.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IVeterinaryRepository
    {
        Task<ResponseEntity> AddNewVeterinary(Veterinary veterinary);
        Task<IEnumerable<Veterinary>> GetAllVeterinary();
        Task<Veterinary> GetVeterinaryById(int id);
        Task<ResponseEntity> UpdateVeterinary(int id, Veterinary veterinary);
        Task DeleteVeterinary(int id);
        Task<ResponseEntity> ReturnMessage(Veterinary veterinary);
        Task<ResponseEntity> ReturnMessageUpdateVeterinary(int id, Veterinary veterinary);
    }
}
