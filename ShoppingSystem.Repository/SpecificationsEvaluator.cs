using ShoppingSystem.Core.Specifications;

namespace ShoppingSystem.Repository;
// Static: don't need to make an object from it ,call the method directly.
internal static class SpecificationsEvaluator<TEntity> where TEntity : BaseModel
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> baseQuery,
        ISpecification<TEntity> specification)
    {
        var query = baseQuery;//Dbset

        // Apply Filtering (WHERE)
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        // Apply Includes (Eager Loading)
        //Aggregate:Method works on each element in the list and builds a cumulative result.
        query = specification.Includes.Aggregate(
            query,
            (current, includeExpression) => current.Include(includeExpression)
        );

        return query;
    }

}
