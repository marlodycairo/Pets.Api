using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Models
{
    public class AgendaDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int OwnerId { get; set; }
        public int PetId { get; set; }
        public OwnerDto OwnerDto { get; set; }
        public PetDto PetDto { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();
    }
}
