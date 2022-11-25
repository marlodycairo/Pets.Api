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
    public class HistoryRepository : IHistoryRepository
    {
        private readonly ApplicationDbContext context;

        public HistoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ResponseEntity> CreateNewHistory(History history)
        {
            IQueryable<History> histories = context.Histories;

            var historyExist = await context.Histories.AnyAsync(h => h.Id == history.Id);

            if (historyExist)
            {
                return new ResponseEntity { Message = ResponseMessage.RecordExist };
            }
            else if (history == null)
            {
                return new ResponseEntity { Message = ResponseMessage.RecordIsNull };
            }

            context.Histories.Add(history);

            context.ChangeTracker.DetectChanges();

            await context.SaveChangesAsync();

            return new ResponseEntity { Id = history.Id, Message = ResponseMessage.RecordSuccessfullSaved };
        }

        public async Task<IEnumerable<History>> GetAllHistories()
        {
            return await context.Histories.ToListAsync();
        }

        public async Task<History> GetHistoryById(int id)
        {
            var historyExist = await context.Histories.AnyAsync(p => p.Id == id);

            if (!historyExist)
            {
                return new History { Id = 0, Date = DateTime.Today, AgendaId = 0, Comment = "", OwnerId = 0, PetId = 0, VeterinaryId = 0 };
            }

            return await context.Histories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ResponseEntity> UpdateHistory(int id, History history)
        {
            var result = await UpdatedHistory(id, history);

            return result;
        }

        public async Task<ResponseEntity> UpdatedHistory(int id, History history)
        {
            var historyExist = await context.Histories.AnyAsync(p => p.Id == id);

            if (!historyExist)
            {
                return new ResponseEntity { Message = ResponseMessage.RecordNotExist };
            }

            context.Histories.Update(history);

            await context.SaveChangesAsync();

            return new ResponseEntity { Message = ResponseMessage.RecordUpdated };
        }
    }
}
