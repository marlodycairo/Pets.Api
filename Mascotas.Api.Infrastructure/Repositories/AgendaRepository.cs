using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using Mascotas.Api.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ResponseEntity> AddNewAgenda(Agenda agenda)
        {
            var result = await ReturnMessage(agenda);

            return result;
        }

        public async Task<ResponseEntity> ReturnMessage(Agenda agenda)
        {
            var agendaExist = await context.Agendas.AnyAsync(p => p.Id == agenda.Id);

            if (agendaExist)
            {
                return new ResponseEntity
                {
                    Id = agenda.Id,

                    Date = agenda.Date,

                    Message = ResponseMessage.RecordExist
                };
            }
            //var agendaSet = new Agenda() { Date = new DateTime(2021, 10, 22, 16, 30, 00), Comment = "Baño, corte de pelo y uñas.", OwnerId = 5, PetId = 10 };

            //context.Set<Agenda>().Add(agendaSet);

            await context.Agendas.AddAsync(agenda);

            await context.SaveChangesAsync();

            return new ResponseEntity
            {
                Id = agenda.Id,

                Date = agenda.Date,

                Message = ResponseMessage.RecordSuccessfullSaved
            };
        }

        public async Task DeleteAgenda(int id)
        {
            var agenda = await context.Agendas.FirstOrDefaultAsync(p => p.Id == id);

            context.Remove(agenda);

            context.ChangeTracker.DetectChanges();

            await context.SaveChangesAsync();
        }

        public async Task<Agenda> GetAgendaById(int id)
        {
            var agenda = await context.Agendas.FirstOrDefaultAsync(p => p.Id == id);

            return agenda;
        }

        public async Task<IEnumerable<Agenda>> GetAllAgendas()
        {
            //return await context.Set<Agenda>().ToListAsync();
            //IQueryable<Agenda> agendas = context.Agendas;
            //return agendas.ToList();

            return await context.Agendas.ToListAsync();
        }

        public async Task<ResponseEntity> UpdateAgenda(Agenda agenda)
        {
            var result = await ReturnMessageUpdateAgenda(agenda);

            return result;
        }

        public async Task<ResponseEntity> ReturnMessageUpdateAgenda(Agenda agenda)
        {
            var agendaExist = await context.Agendas.AnyAsync(p => p.Id == agenda.Id);

            if (!agendaExist)
            {
                return new ResponseEntity
                {                    
                    Date = agenda.Date,

                    Message = ResponseMessage.RecordNotExist
                };
            }
            context.Entry(agenda).State = EntityState.Modified;

            context.ChangeTracker.DetectChanges();

            await context.SaveChangesAsync();

            return new ResponseEntity
            {
                Id = agenda.Id,

                Date = agenda.Date,

                Message = ResponseMessage.RecordUpdated
            };
        }

    }
}
