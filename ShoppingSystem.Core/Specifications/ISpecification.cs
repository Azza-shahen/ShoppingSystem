using ShoppingSystem.Core.Entities;
using System.Linq.Expressions;

namespace ShoppingSystem.Core.Specifications;
    public interface ISpecification<T> where T : BaseModel
    {
    Expression<Func<T, bool>>? Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    }

