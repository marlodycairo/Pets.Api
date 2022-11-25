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
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseEntity> AddPet(Pet pet)
        {
            var result = await ReturnMessage(pet);

            return result;
        }

        public async Task<ResponseEntity> ReturnMessage(Pet pet)
        {
            var petExist = await _context.Pets.AnyAsync(p => p.Id == pet.Id);
 
            if (petExist)
            {
                return new ResponseEntity 
                {
                    Id = pet.Id,

                    PropertyName = pet.Name,

                    Message = ResponseMessage.RecordExist
                };
            }
            else if (pet == null)
            {
                return new ResponseEntity
                {
                    Message = ResponseMessage.RecordIsNull
                };
            }

            await _context.Pets.AddAsync(pet);

            await _context.SaveChangesAsync();

            return new ResponseEntity
            {
                Id = pet.Id,

                PropertyName = pet.Name,

                Message = ResponseMessage.RecordSuccessfullSaved
            };
        }

        public async Task DeletePet(int id)
        {
            var pet = await _context.Pets.SingleAsync(p => p.Id == id);

            _context.Pets.Remove(pet);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            return await _context.Pets.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            //var findPetById = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            var pets = _context.Pets
                
                .Include(p => p.Owner)
            
                .Where(p => p.Id == id);

            //var queryString = pets.ToQueryString();

            return await pets.FirstOrDefaultAsync();
        }

        public async Task<ResponseEntity> UpdatePet(int id, Pet pet)
        {
            var result = await ReturnMessageUpdatePet(id, pet);

            return result;
        }

        public async Task<ResponseEntity> ReturnMessageUpdatePet(int id, Pet pet)
        {
            var petExist = await _context.Pets.AnyAsync(p => p.Id == id);

            if (!petExist)
            {
                return new ResponseEntity
                {
                    Id = pet.Id,

                    PropertyName = pet.Name,

                    Message = ResponseMessage.RecordNotExist
                };
            }
            if (id == pet.Id)
            {
                _context.Update(pet);

                await _context.SaveChangesAsync();
            }

            return new ResponseEntity
            {
                Id = pet.Id,

                PropertyName = pet.Name,

                Message = ResponseMessage.RecordUpdated
            };
        }
    }
}
