using System.Linq.Expressions;
using System.Reflection;

namespace Monad;

public static class ExpressionExtensions
{
    public static object? GetContext(this Expression expression) => expression switch
    {
        ConstantExpression constantExpression => constantExpression.Value,
        LambdaExpression lambdaExpression => GetContext(lambdaExpression.Body),
        MemberExpression { Expression: not null } memberExpression => GetContext(memberExpression.Expression),
        _ => throw new ArgumentException($"Expression type '{expression.Type}' is not supported", nameof(expression))
    };

    public static PropertyInfo GetPropertyInfo(this Expression expression) => expression switch
    {
        LambdaExpression lambdaExpression => GetPropertyInfo(lambdaExpression.Body),
        MemberExpression { Member: PropertyInfo property } => property,
        _ => throw new ArgumentException($"Expression '{expression}' does not resolve to a property", nameof(expression))
    };
}
