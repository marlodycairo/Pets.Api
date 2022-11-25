using Mascotas.Api.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class ResponseEntity
    {
        public int Id { get; set; }
        public int PropertyNumeric { get; set; }
        public string PropertyName { get; set; }
        public string PropertyName2 { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
