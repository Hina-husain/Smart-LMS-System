using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLMS.Interfaces
{
    // CONCEPT: Interface Segregation Principle (SOLID) & Generics (OOP)
    // This defines a contract for generic CRUD operations.
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
