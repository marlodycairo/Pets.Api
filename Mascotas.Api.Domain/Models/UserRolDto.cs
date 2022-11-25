using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Models
{
    public class UserRolDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RolId { get; set; }
    }
}
