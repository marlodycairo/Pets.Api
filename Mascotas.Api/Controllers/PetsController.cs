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
    public class PetsController : ControllerBase
    {
        private readonly IPetApplication petApplication;

        public PetsController(IPetApplication petApplication)
        {
            this.petApplication = petApplication;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseEntityDto>> CreatePet(PetDto pet)
        {
            var petResult = await petApplication.AddPet(pet);

            return petResult;
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IEnumerable<PetDto>> GetPets()
        {
            var pets = await petApplication.GetAllPets();

            return pets.ToList();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<PetDto>> GetPet(int id)
        {
            var pet = await petApplication.GetPetById(id);

            return Ok(pet);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponseEntityDto>> UpdatePet(int id, PetDto petDto)
        {
            var pet = await petApplication.UpdatePet(id, petDto);

            return Ok(pet);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task DeletePet(int id)
        {
            await petApplication.DeletePet(id);
        }
    }
}
