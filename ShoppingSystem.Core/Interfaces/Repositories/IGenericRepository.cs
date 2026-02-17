using ShoppingSystem.Core.Entities;
using ShoppingSystem.Core.Specifications;
namespace ShoppingSystem.Core.Interfaces.Repositories;
 public interface IGenericRepository<T> where T : BaseModel
 {
    Task<T?> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
    Task<T?> GetWithSpecAsync(ISpecification<T> spec);
 }

