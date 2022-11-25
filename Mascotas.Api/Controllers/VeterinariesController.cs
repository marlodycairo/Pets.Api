using Mascotas.Api.Application;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Domain.QueryFiltersModels;
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
    public class VeterinariesController : ControllerBase
    {
        private readonly IVeterinaryApplication veterinary;

        public VeterinariesController(IVeterinaryApplication veterinary)
        {
            this.veterinary = veterinary;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponseEntityDto>> CreateNewVeterinary(VeterinaryDto veterinaryDto)
        {
            var veterinaryAdded = await veterinary.AddNewVeterinary(veterinaryDto);

            return Ok(veterinaryAdded);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IEnumerable<VeterinaryDto>> GetAllVeterinaries([FromQuery] VeterinaryQueryFilterModel filter)
        {
            var veterinaries = await veterinary.GetAllVeterinary(filter);

            return veterinaries.ToList();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<VeterinaryDto>> GetVeterinary(int id)
        {
            var veterinaryById = await veterinary.GetVeterinaryById(id);

            return Ok(veterinaryById);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponseEntityDto>> UpdateAgenda(int id, VeterinaryDto veterinaryDto)
        {
            var veterinaryUpdated = await veterinary.UpdateVeterinary(id, veterinaryDto);

            return Ok(veterinaryUpdated);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task DeleteAgendaById(int id)
        {
            await veterinary.DeleteVeterinary(id);
        }
    }
}
