using AutoMapper;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.DomainServices
{
    public class HistoryDomainService : IHistoryDomain
    {
        private readonly IHistoryRepository historyRepository;
        private readonly IMapper mapper;

        public HistoryDomainService(IHistoryRepository historyRepository, IMapper mapper)
        {
            this.historyRepository = historyRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseEntityDto> CreateNewHistory(HistoryDto historyDto)
        {
            var historyMap = mapper.Map<History>(historyDto);

            var history = await historyRepository.CreateNewHistory(historyMap);

            var response = mapper.Map<ResponseEntityDto>(history);

            return response;
        }

        public async Task<IEnumerable<HistoryDto>> GetAllHistories()
        {
            var history = await historyRepository.GetAllHistories();

            var histories = mapper.Map<IEnumerable<HistoryDto>>(history);
            
            return histories;
        }

        public async Task<HistoryDto> GetHistoryById(int id)
        {
            var history = await historyRepository.GetHistoryById(id);

            var historyById = mapper.Map<HistoryDto>(history);

            return historyById;
        }

        public async Task<ResponseEntityDto> UpdateHistory(int id, HistoryDto historyDto)
        {
            var historyMapper = mapper.Map<History>(historyDto);

            var history = await historyRepository.UpdateHistory(id, historyMapper);

            var response = mapper.Map<ResponseEntityDto>(history);

            return response;
        }
    }
}
