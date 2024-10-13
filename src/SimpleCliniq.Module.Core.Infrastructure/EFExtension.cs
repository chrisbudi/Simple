using System.Linq.Expressions;

namespace SimpleCliniq.Module.Core.Infrastructure;

public static class EFExtension
{
    public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string orderByProperty, bool asc)
    {
        var command = asc ? "OrderBy" : "OrderByDescending";
        var type = typeof(T);
        var property = type.GetProperty(orderByProperty);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var resultExpression = Expression.Call(typeof(Queryable), command, [type, property.PropertyType],
                                                source.Expression, Expression.Quote(orderByExpression));
        return source.Provider.CreateQuery<T>(resultExpression);
    }
}
