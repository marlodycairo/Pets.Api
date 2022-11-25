using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext context;

        public OwnerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Owner> AddOwner(Owner owner)
        {
            await context.Owners.AddAsync(owner);

            await context.SaveChangesAsync();

            return owner;
        }
    }
}
