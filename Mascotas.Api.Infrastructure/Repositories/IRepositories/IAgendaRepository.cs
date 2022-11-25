using Mascotas.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories.IRepositories
{
    public interface IAgendaRepository
    {
        Task<ResponseEntity> AddNewAgenda(Agenda agenda);
        Task<IEnumerable<Agenda>> GetAllAgendas();
        Task<Agenda> GetAgendaById(int id); 
        Task<ResponseEntity> UpdateAgenda(Agenda agenda);
        Task DeleteAgenda(int id);
        Task<ResponseEntity> ReturnMessage(Agenda agenda);
        Task<ResponseEntity> ReturnMessageUpdateAgenda(Agenda agenda);
    }
}
