using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationCard { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
