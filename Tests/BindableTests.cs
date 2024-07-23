using Microsoft.AspNetCore.Components;

namespace Monad;

internal sealed class BindableTests
{
    [Test]
    public async Task TestApply()
    {
        var component = Substitute.For<FakeComponent>();
        var bindable = new Bindable<FakeComponent>();

        await bindable.Apply(component);
        await component.DidNotReceive().SetParametersAsync(Arg.Any<ParameterView>());

        bindable.Set(c => c.Value, 42);
        await bindable.Apply(component);
        await component.Received().SetParametersAsync(Arg.Any<ParameterView>());
    }

    [Test]
    public void TestSet()
    {
        var bindable = new Bindable<FakeComponent>();
        Assert.Throws<ArgumentException>(() => bindable.Set(c => c.ValueWithoutParameter, 42));

        bindable.Set(c => c.Value, 42);
        Assert.That(bindable.Values, Contains.Key(nameof(FakeComponent.Value)).WithValue(42));
    }

    [Test]
    public void TestValues()
    {
        var bindable = new Bindable<ComponentBase>();
        Assert.That(bindable.Values, Is.Empty);
    }

    internal class FakeComponent : ComponentBase
    {
        [Parameter]
        public int Value { get; set; }

        public int ValueWithoutParameter { get; set; }
    }
}
