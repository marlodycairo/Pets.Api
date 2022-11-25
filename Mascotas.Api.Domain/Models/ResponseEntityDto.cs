using Mascotas.Api.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Models
{
    public class ResponseEntityDto
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
