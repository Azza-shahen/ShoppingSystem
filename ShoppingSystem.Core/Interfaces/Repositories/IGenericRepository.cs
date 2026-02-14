using ShoppingSystem.Core.Entities;
namespace ShoppingSystem.Core.Interfaces.Repositories;
    public interface IGenericRepository<T> where T : BaseModel
    {
    public Task<T?> GetAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
}

