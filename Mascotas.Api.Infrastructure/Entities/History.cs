using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class History
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int VeterinaryId { get; set; }
        public int AgendaId { get; set; }
        public int PetId { get; set; }
        public int OwnerId { get; set; }
        public Veterinary Veterinary { get; set; }
        public Agenda Agenda { get; set; }
        public Pet Pet { get; set; }
        public Owner Owner { get; set; }
    }
}
