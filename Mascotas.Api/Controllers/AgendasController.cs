using Mascotas.Api.Application;
using Mascotas.Api.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaApplication agendaApplication;

        public AgendasController(IAgendaApplication agendaApplication)
        {
            this.agendaApplication = agendaApplication;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponseEntityDto>> CreateNewOwner(AgendaDto agenda)
        {
            var resultAgenda = await agendaApplication.AddNewAgenda(agenda);

            return Ok(resultAgenda);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IEnumerable<AgendaDto>> GetAgendas()
        {
            var agendas = await agendaApplication.GetAllAgendas();

            return agendas.ToList();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<AgendaDto>> GetAgenda(int id)
        {
            var agenda = await agendaApplication.GetAgendaById(id);

            return Ok(agenda);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponseEntityDto>> UpdateAgenda(int id, AgendaDto agenda)
        {
            var agendaUpdate = await agendaApplication.UpdateAgenda(agenda);

            return Ok(agendaUpdate);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task DeleteAgendaById(int id)
        {
            await agendaApplication.DeleteAgenda(id);
        }
    }
}
