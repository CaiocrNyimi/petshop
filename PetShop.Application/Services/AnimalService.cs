using PetShop.Application.Interfaces;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Application.Services
{
    public class AnimalService : InterfaceAnimalService
    {
        private readonly PetShopContext _context;
        public AnimalService(PetShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animais.ToListAsync();
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            return await _context.Animais.FindAsync(id);
        }

        public async Task AddAsync(Animal animal)
        {
            _context.Animais.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var animal = await _context.Animais.FindAsync(id);
            if (animal != null)
            {
                _context.Animais.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
