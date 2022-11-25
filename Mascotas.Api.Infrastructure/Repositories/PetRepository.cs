using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Entities;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
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

        public async Task<Pet> AddPet(Pet pet)
        {
            await _context.Pets.AddAsync(pet);

            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task DeletePet(int id)
        {
            var petById = _context.Pets.FindAsync(id);

            _context.Remove(petById);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            var findPetById = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);

            return findPetById;
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            _context.Update(pet);

            await _context.SaveChangesAsync();

            return pet;
        }
    }
}
