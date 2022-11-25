using Mascotas.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IAgendaRepository
    {
        Task<Agenda> AddNewAgenda(Agenda agenda);
        Task<IEnumerable<Agenda>> GetAllAgendas();
        Task<Agenda> GetAgendaById(int id); 
        Task<Agenda> UpdateAgenda(Agenda agenda);
        Task DeleteAgenda(int id);
    }
}
