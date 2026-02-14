using ShoppingSystem.Core.Interfaces.Repositories;
using ShoppingSystem.Repository.Data;
using System.Collections.Generic;


namespace ShoppingSystem.Repository;
public class GenericRepository<T>(ShoppingSystemDbContext _dbContext) : IGenericRepository<T> where T : BaseModel
{
    public async Task<IEnumerable<T>> GetAllAsync()
    {
       if(typeof(T) == typeof(Product))
           return (IEnumerable<T>) await _dbContext.Set<Product>()
                 .Include(p=>p.Brand).Include(p => p.Category).ToListAsync();
      return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetAsync(int id)
    {
        if (typeof(T) == typeof(Product))
            return await _dbContext.Set<Product>()
                  .Where(p => p.Id == id).Include(p => p.Brand)
                  .Include(p => p.Category).FirstOrDefaultAsync() as T;
        return await _dbContext.Set<T>().FindAsync(id);// FindAsync return object or null so must be nullable
    }
}

