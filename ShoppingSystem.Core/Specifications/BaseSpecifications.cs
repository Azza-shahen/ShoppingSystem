using ShoppingSystem.Core.Entities;
using System.Linq.Expressions;

namespace ShoppingSystem.Core.Specifications;

public class BaseSpecifications<T> : ISpecification<T> where T : BaseModel
{
    public Expression<Func<T, bool>>? Criteria { get; protected set; }
    public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

    protected BaseSpecifications()
    {
        // Criteria = null;
    }

    protected BaseSpecifications(Expression<Func<T, bool>> criteriaExpression)
    {
        Criteria = criteriaExpression; // P => P.Id == 10
    }
}

