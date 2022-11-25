using Mascotas.Api.Application;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.ApplicationServices
{
    public class AgendaApplicationService : IAgendaApplication
    {
        private readonly IAgendaDomain agendaDomain;

        public AgendaApplicationService(IAgendaDomain agendaDomain)
        {
            this.agendaDomain = agendaDomain;
        }

        public async Task<AgendaDto> AddNewAgenda(AgendaDto agenda)
        {
            return await agendaDomain.AddAgenda(agenda);
        }

        public async Task DeleteAgenda(int id)
        {
            await agendaDomain.DeleteAgenda(id);
        }

        public async Task<AgendaDto> GetAgendaById(int id)
        {
            return await agendaDomain.GetAgendaById(id);
        }

        public async Task<IEnumerable<AgendaDto>> GetAllAgendas()
        {
            return await agendaDomain.GetAllAgendas();
        }

        public async Task<AgendaDto> UpdateAgenda(AgendaDto agenda)
        {
            return await agendaDomain.UpdateAgenda(agenda);
        }
    }
}
