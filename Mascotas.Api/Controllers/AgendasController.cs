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
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaApplication agendaApplication;

        public AgendasController(IAgendaApplication agendaApplication)
        {
            this.agendaApplication = agendaApplication;
        }

        [HttpPost]
        public async Task<ActionResult<AgendaDto>> CreateNewOwner(AgendaDto agenda)
        {
            var newAgenda = await agendaApplication.AddNewAgenda(agenda);

            return Ok(newAgenda);
        }

        [HttpGet]
        public async Task<IEnumerable<AgendaDto>> GetAgendas()
        {
            var agendas = await agendaApplication.GetAllAgendas();

            return agendas.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendaDto>> GetAgenda(int id)
        {
            var agenda = await agendaApplication.GetAgendaById(id);

            return Ok(agenda);
        }

        [HttpPut]
        public async Task<ActionResult<AgendaDto>> UpdateAgenda(int id, AgendaDto agenda)
        {
            if (id != agenda.Id)
            {
                return BadRequest();
            }
            var agendaUpdate = await agendaApplication.UpdateAgenda(agenda);

            return Ok(agendaUpdate);
        }

        [HttpDelete]
        public async Task DeleteAgendaById(int id)
        {
            await agendaApplication.DeleteAgenda(id);
        }
    }
}
