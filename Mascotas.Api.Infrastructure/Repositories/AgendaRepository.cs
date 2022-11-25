using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly ApplicationDbContext context;

        public AgendaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Agenda> AddNewAgenda(Agenda agenda)
        {
            var dateExists = await context.Agendas.AnyAsync(p => p.Date == agenda.Date);

            if (dateExists)
            {
                agenda = new Agenda
                {
                    Id = 0,
                    Comment = "",
                    Date = DateTime.Today,
                    PetId = 0,
                    OwnerId = 0
                };
                return agenda;
            }
            await context.Agendas.AddAsync(agenda);

            await context.SaveChangesAsync();

            return agenda;
        }

        public async Task DeleteAgenda(int id)
        {
            var agenda = context.Agendas.FindAsync(id);

            context.Remove(agenda);

            await context.SaveChangesAsync();
        }

        public async Task<Agenda> GetAgendaById(int id)
        {
            var agenda = await context.Agendas.FirstOrDefaultAsync(p => p.Id == id);

            return agenda;
        }

        public async Task<IEnumerable<Agenda>> GetAllAgendas()
        {
            return await context.Agendas.ToListAsync();
        }

        public async Task<Agenda> UpdateAgenda(Agenda agenda)
        {
            context.Update(agenda);

            await context.SaveChangesAsync();

            return agenda;
        }
    }
}
