using PetShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Application.Interfaces
{
    public interface InterfaceAnimalService
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal> GetByIdAsync(int id);
        Task AddAsync(Animal animal);
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(int id);
    }
}
