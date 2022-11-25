using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.QueryFiltersModels
{
    public class VeterinaryQueryFilterModel
    {
        public int IdVeterinary { get; set; }
        public int IDCard { get; set; }
        public string FullName { get; set; }
        public int Speciality { get; set; }
    }
}
