using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Domain
{
    public interface IAgendaDomain
    {
        Task<ResponseEntityDto> AddAgenda(AgendaDto agenda);
        Task<IEnumerable<AgendaDto>> GetAllAgendas();
        Task<AgendaDto> GetAgendaById(int id);
        Task<ResponseEntityDto> UpdateAgenda(AgendaDto agenda);
        Task DeleteAgenda(int id);
    }
}
