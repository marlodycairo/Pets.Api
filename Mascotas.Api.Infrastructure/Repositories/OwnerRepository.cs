using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using Mascotas.Api.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ResponseEntity> AddOwner(Owner owner)
        {
            var newOwner = await ReturnMessage(owner);

            return newOwner;
        }

        public async Task DeleteOwner(int id)
        {
            var ownerExist = await context.Owners.AnyAsync(p => p.Id == id);

            if (ownerExist)
            {
                var owner = await context.Owners.FindAsync(id);

                context.Owners.Remove(owner);

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            return await context.Owners

                .Include(p => p.Pets)

                .ToListAsync();
        }

        public async Task<Owner> GetOwnerById(int id)
        {
            IQueryable<Owner> owner = context.Owners;

            return await owner.SingleAsync(p => p.Id == id);
        }

        public async Task<ResponseEntity> ReturnMessage(Owner owner)
        {
            var ownerExist = await context.Owners.AnyAsync(p => p.Id == owner.Id);

            if (ownerExist)
            {
                return new ResponseEntity
                {
                    Id = owner.Id,

                    PropertyName = owner.FirstName + " " + owner.LastName,

                    Message = ResponseMessage.RecordExist
                };
            }
            else if (owner == null)
            {
                return new ResponseEntity
                {
                    Message = ResponseMessage.RecordIsNull
                };
            }

            await context.Owners.AddAsync(owner);

            await context.SaveChangesAsync();

            return new ResponseEntity
            {
                Id = owner.Id,

                PropertyName = owner.FirstName + " " + owner.LastName,

                Message = ResponseMessage.RecordSuccessfullSaved
            };
        }

        public async Task<ResponseEntity> UpdateOwner(Owner owner)
        {
            var result = await ReturnMessageUpdateOwner(owner);

            return result;
        }

        public async Task<ResponseEntity> ReturnMessageUpdateOwner(Owner owner)
        {
            var ownerExist = await context.Owners.AnyAsync(p => p.Id == owner.Id);

            if (!ownerExist)
            {
                return new ResponseEntity
                {
                    Id = owner.Id,

                    PropertyName = owner.FirstName + " " + owner.LastName,

                    Message = ResponseMessage.RecordNotExist
                };
            }
            context.Owners.Update(owner);

            await context.SaveChangesAsync();

            return new ResponseEntity
            {
                Id = owner.Id,

                PropertyName = owner.FirstName + " " + owner.LastName,

                Message = ResponseMessage.RecordUpdated
            };
        }
    }
}
