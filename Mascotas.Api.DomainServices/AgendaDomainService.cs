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

        public async Task<ResponseEntityDto> AddAgenda(AgendaDto agenda)
        {
            var agendaMapper = mapper.Map<Agenda>(agenda);

            var returnAgendaResponse = await agendaRepository.ReturnMessage(agendaMapper);

            var agendaResponse = mapper.Map<ResponseEntityDto>(returnAgendaResponse);

            return agendaResponse;
        }

        public async Task DeleteAgenda(int id)
        {
            await agendaRepository.DeleteAgenda(id);
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

        public async Task<ResponseEntityDto> UpdateAgenda(AgendaDto agenda)
        {
            var agendaMapper = mapper.Map<Agenda>(agenda);

            var returnAgendaResponse = await agendaRepository.ReturnMessageUpdateAgenda(agendaMapper);

            var agendaResponse = mapper.Map<ResponseEntityDto>(returnAgendaResponse);

            return agendaResponse;
        }
    }
}
