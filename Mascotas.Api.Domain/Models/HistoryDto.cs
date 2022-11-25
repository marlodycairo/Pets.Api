using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Models
{
    public class HistoryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int VeterinaryId { get; set; }
        public int AgendaId { get; set; }
        public int PetId { get; set; }
        public int OwnerId { get; set; }
        public VeterinaryDto VeterinaryDto { get; set; }
        public AgendaDto AgendaDto { get; set; }
        public PetDto PetDto { get; set; }
        public OwnerDto OwnerDto { get; set; }
    }
}
