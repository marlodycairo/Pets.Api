using Mascotas.Api.Domain.Models;
using Mascotas.Api.Domain.QueryFiltersModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Application
{
    public interface IVeterinaryApplication
    {
        Task<ResponseEntityDto> AddNewVeterinary(VeterinaryDto veterinary);
        Task<IEnumerable<VeterinaryDto>> GetAllVeterinary(VeterinaryQueryFilterModel filter);
        Task<VeterinaryDto> GetVeterinaryById(int id);
        Task<ResponseEntityDto> UpdateVeterinary(int id, VeterinaryDto veterinary);
        Task DeleteVeterinary(int id);
    }
}
