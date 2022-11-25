using Mascotas.Api.Application;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.ApplicationServices
{
    public class HistoryApplicationService : IHistoryApplication
    {
        private readonly IHistoryDomain historyDomain;

        public HistoryApplicationService(IHistoryDomain historyDomain)
        {
            this.historyDomain = historyDomain;
        }

        public async Task<ResponseEntityDto> CreateNewHistory(HistoryDto history)
        {
            return await historyDomain.CreateNewHistory(history);
        }

        public async Task<IEnumerable<HistoryDto>> GetAllHistories()
        {
            return await historyDomain.GetAllHistories();
        }

        public async Task<HistoryDto> GetHistoryById(int id)
        {
            return await historyDomain.GetHistoryById(id);
        }

        public async Task<ResponseEntityDto> UpdateHistory(int id, HistoryDto history)
        {
            return await historyDomain.UpdateHistory(id, history);
        }
    }
}
