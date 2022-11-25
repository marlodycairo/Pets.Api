using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class Veterinary
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int IDCard { get; set; }
        public int CellPhone { get; set; }
        public int SpecialityId { get; set; }
        public string Address { get; set; }
        public Speciality Speciality { get; set; }
    }
}
