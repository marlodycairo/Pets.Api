using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Models
{
    public class SpecialityDto
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        public VeterinaryDto VeterinaryDto { get; set; }
    }
}
