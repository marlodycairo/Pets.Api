using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Models
{
    public class LoginDto
    {
        public string User { get; set; }
        public string Pass { get; set; }
    }
}
