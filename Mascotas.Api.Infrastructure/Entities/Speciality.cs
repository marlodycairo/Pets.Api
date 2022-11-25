using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class Speciality
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        public Veterinary Veterinary { get; set; }
    }
}
