using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class UserRol
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RolId { get; set; }
        public User User { get; set; }
        public Rol Rol { get; set; }
    }
}
