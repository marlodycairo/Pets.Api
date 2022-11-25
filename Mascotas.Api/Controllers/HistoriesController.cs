using Mascotas.Api.Application;
using Mascotas.Api.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mascotas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly IHistoryApplication historyApplication;

        public HistoriesController(IHistoryApplication historyApplication)
        {
            this.historyApplication = historyApplication;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseEntityDto>> AddNewHistory(HistoryDto historyDto)
        {
            var history = await historyApplication.CreateNewHistory(historyDto);

            return Ok(history);
        }

        [HttpGet]
        public async Task<IEnumerable<HistoryDto>> GetHistories()
        {
            var histories = await historyApplication.GetAllHistories();

            return histories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryDto>> GetHistory(int id)
        {
            var history = await historyApplication.GetHistoryById(id);

            return Ok(history);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseEntityDto>> UpdateHistory(int id, HistoryDto historyDto)
        {
            var history = await historyApplication.UpdateHistory(id, historyDto);

            return Ok(history);
        }
    }
}
