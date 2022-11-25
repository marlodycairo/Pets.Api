using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
    }
}
