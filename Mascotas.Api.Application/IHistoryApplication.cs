using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Application
{
    public interface IHistoryApplication
    {
        Task<IEnumerable<HistoryDto>> GetAllHistories();
        Task<HistoryDto> GetHistoryById(int id);
        Task<ResponseEntityDto> UpdateHistory(int id, HistoryDto history);
        Task<ResponseEntityDto> CreateNewHistory(HistoryDto history);
    }
}
