using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Monad;

internal sealed class BindingTests
{
    [Test]
    public async Task TestApply()
    {
        var apply = Substitute.For<Action>();
        var binding = new FakeBinding(apply);
        await binding.Apply(Substitute.For<ComponentBase>(), () => 42);
        apply.Received().Invoke();
    }

    private sealed class FakeBinding(Action apply) : Binding<ComponentBase, int>
    {
        protected override void Apply(Bindable<ComponentBase> bindable, Expression<Func<int>> expression)
            => apply();
    }
}
