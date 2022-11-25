using Mascotas.Api.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Photo { get; set; }
        public DateTime Born { get; set; }
        public int OwnerId { get; set; }
        public PetType PetTypes { get; set; }
        public Owner Owner { get; set; }

        public DateTime DateLocal => Born.ToLocalTime();
    }
}
