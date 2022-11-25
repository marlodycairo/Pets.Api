using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Application
{
    public interface IAgendaApplication
    {
        Task<AgendaDto> AddNewAgenda(AgendaDto agenda);
        Task<IEnumerable<AgendaDto>> GetAllAgendas();
        Task<AgendaDto> GetAgendaById(int id);
        Task<AgendaDto> UpdateAgenda(AgendaDto agenda);
        Task DeleteAgenda(int id);
    }
}
