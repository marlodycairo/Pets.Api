using Mascotas.Api.Application;
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
    public class PetsOwnersController : ControllerBase
    {
        private readonly IPetApplication petApplication;
        private readonly IOwnerApplication ownerApplication;

        public PetsOwnersController(IPetApplication petApplication, IOwnerApplication ownerApplication)
        {
            this.petApplication = petApplication;
            this.ownerApplication = ownerApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwnersWithPets()
        {
            var pets = await petApplication.GetAllPets();
            var owners = await ownerApplication.GetAllOwner();

            pets.OrderBy(p => p.Name).LastOrDefault();

            return Ok(pets);
        }
    }
}
