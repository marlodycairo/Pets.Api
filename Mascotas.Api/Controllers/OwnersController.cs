
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
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerApplication ownerApplication;

        public OwnersController(IOwnerApplication ownerApplication)
        {
            this.ownerApplication = ownerApplication;
        }

        [HttpPost]
        public async Task<ActionResult<OwnerDto>> CreateNewOwner(OwnerDto owner)
        {
            var newOwner = await ownerApplication.AddOwner(owner);

            return Ok(newOwner);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IEnumerable<OwnerDto>> GetOwners()
        {
            var owners = await ownerApplication.GetAllOwner();

            return owners.ToList();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<OwnerDto>> GetOwner(int id)
        {
            var owner = await ownerApplication.GetOwnerById(id);

            return Ok(owner);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponseEntityDto>> UpdateOwner(OwnerDto owner)
        {
            var ownerUpdate = await ownerApplication.UpdateOwner(owner);

            return Ok(ownerUpdate);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task DeleteOwnerById(int id)
        {
            await ownerApplication.DeleteOwner(id);
        }
    }
}
