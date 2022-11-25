using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int OwnerId { get; set; }
        public int PetId { get; set; }
        public Owner Owner { get; set; }
        public Pet Pet { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();
    }
}
