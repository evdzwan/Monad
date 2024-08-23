using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Monad;

internal sealed class BinderTests
{
    [Test]
    public void TestBind()
    {
        var serviceProvider = Substitute.For<IServiceProvider>();
        var binder = new Binder(serviceProvider);

        var component = Substitute.For<ComponentBase>();
        Assert.ThrowsAsync<InvalidOperationException>(async () => await binder.Bind(component, () => 42));

        var apply = Substitute.For<Action>();
        serviceProvider.GetService(typeof(Binding<ComponentBase, int>)).Returns(new FakeBinding(apply));
        Assert.DoesNotThrowAsync(async () => await binder.Bind(component, () => 42));
        apply.Received().Invoke();
    }

    private sealed class FakeBinding(Action apply) : Binding<ComponentBase, int>
    {
        protected override void Apply(Bindable<ComponentBase> bindable, Expression<Func<int>> expression)
            => apply();
    }
}
