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
    }
}
