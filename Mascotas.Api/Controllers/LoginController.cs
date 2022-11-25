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
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplication loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            this.loginApplication = loginApplication;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginDto login)
        {
            ActionResult response = Unauthorized();

            var user = loginApplication.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = loginApplication.GenerateJsonWebToken(user);

                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpGet]
        public void Logout()
        {

        }
    }
}
