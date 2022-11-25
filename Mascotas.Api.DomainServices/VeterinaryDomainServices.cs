using AutoMapper;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Domain.QueryFiltersModels;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.DomainServices
{
    public class VeterinaryDomainServices : IVeterinaryDomain
    {
        private readonly IVeterinaryRepository veterinaryRepository;
        private readonly IMapper mapper;

        public VeterinaryDomainServices(IVeterinaryRepository veterinaryRepository, IMapper mapper)
        {
            this.veterinaryRepository = veterinaryRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseEntityDto> AddNewVeterinary(VeterinaryDto veterinary)
        {
            var veterinaryMapper = mapper.Map<Veterinary>(veterinary);

            var returnVeterinaryResponse = await veterinaryRepository.ReturnMessage(veterinaryMapper);

            var veterinaryResponse = mapper.Map<ResponseEntityDto>(returnVeterinaryResponse);

            return veterinaryResponse;
        }

        public async Task DeleteVeterinary(int id)
        {
            await veterinaryRepository.DeleteVeterinary(id);
        }

        public async Task<IEnumerable<VeterinaryDto>> GetAllVeterinary(VeterinaryQueryFilterModel filter)
        {
            var veterinaries = await veterinaryRepository.GetAllVeterinary();

            var allVeterinaries = mapper.Map<IEnumerable<VeterinaryDto>>(veterinaries);

            if (filter.IdVeterinary != 0)
            {
                allVeterinaries = allVeterinaries.Where(v => v.Id == filter.IdVeterinary);
            }

            if (filter.IDCard != 0)
            {
                allVeterinaries = allVeterinaries.Where(v => v.IDCard == filter.IDCard);
            }

            if (filter.FullName != null)
            {
                allVeterinaries = allVeterinaries.Where(v => v.FullName.StartsWith(filter.FullName) == filter.FullName.StartsWith(filter.FullName)).OrderBy(p => p.FullName).ToList();
            }

            if (filter.Speciality !=0)
            {
                //List<VeterinaryDto> vets = allVeterinaries.ToList();

                //var resultVets = vets.GroupBy(p => p.SpecialityId).OrderBy(p => p.Key);

                //foreach (var item in resultVets)
                //{
                //    var vetGroupBy = item.Key;
                //}
                allVeterinaries = allVeterinaries.Where(v => v.SpecialityId == filter.Speciality).OrderBy(p => p.FullName);
            }

            return allVeterinaries;
        }

        public async Task<VeterinaryDto> GetVeterinaryById(int id)
        {
            var veterinaryById = await veterinaryRepository.GetVeterinaryById(id);

            var veterinary = mapper.Map<VeterinaryDto>(veterinaryById);

            return veterinary;
        }

        public async Task<ResponseEntityDto> UpdateVeterinary(int id, VeterinaryDto veterinary)
        {
            var veterinaryMapper = mapper.Map<Veterinary>(veterinary);

            var returnVeterinaryResponse = await veterinaryRepository.ReturnMessageUpdateVeterinary(id, veterinaryMapper);

            var veterinaryResponse = mapper.Map<ResponseEntityDto>(returnVeterinaryResponse);

            return veterinaryResponse;
        }
    }
}
