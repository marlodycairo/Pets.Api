using Mascotas.Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
