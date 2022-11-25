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
    public class AgendaDomainService : IAgendaDomain
    {
        private readonly IAgendaRepository agendaRepository;
        private readonly IMapper mapper;

        public AgendaDomainService(IAgendaRepository agendaRepository, IMapper mapper)
        {
            this.agendaRepository = agendaRepository;
            this.mapper = mapper;
        }

        public async Task<AgendaDto> AddAgenda(AgendaDto agenda)
        {
            var agendaMapper = mapper.Map<Agenda>(agenda);

            await agendaRepository.AddNewAgenda(agendaMapper);

            return agenda;
        }

        public async Task DeleteAgenda(int id)
        {
            var agenda = await agendaRepository.GetAgendaById(id);

            mapper.Map<AgendaDto>(agenda);
        }

        public async Task<AgendaDto> GetAgendaById(int id)
        {
            var agendaById = await agendaRepository.GetAgendaById(id);

            var agenda = mapper.Map<AgendaDto>(agendaById);

            return agenda;
        }

        public async Task<IEnumerable<AgendaDto>> GetAllAgendas()
        {
            var agendas = await agendaRepository.GetAllAgendas();

            var allAgendas = mapper.Map<IEnumerable<AgendaDto>>(agendas);

            return allAgendas;
        }

        public async Task<AgendaDto> UpdateAgenda(AgendaDto agenda)
        {
            var agendaById = mapper.Map<Agenda>(agenda);

            await agendaRepository.UpdateAgenda(agendaById);

            return agenda;
        }
    }
}
