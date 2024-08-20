using System.Linq.Expressions;

namespace Monad;

internal sealed class ExpressionExtensionsTests
{
    private readonly Context _context = new("fake-value");

    private static Expression<Func<T>> ConstructExpression<T>(Expression<Func<T>> expression)
        => expression;

    private static Expression<Func<Context, T>> ConstructExpression<T>(Expression<Func<Context, T>> expression)
        => expression;

    [Test]
    public void TestGetContext()
    {
        var expression = ConstructExpression(() => _context.Value);
        Assert.That(expression.GetContext(), Is.EqualTo(this));
    }

    [Test]
    public void TestGetPropertyInfo()
    {
        var expression = ConstructExpression(item => item.Value);
        Assert.That(expression.GetPropertyInfo(), Is.EqualTo(typeof(Context).GetProperty(nameof(Context.Value))));
    }

    private sealed class Context(string value)
    {
        public string Value { get; } = value;
    }
}
