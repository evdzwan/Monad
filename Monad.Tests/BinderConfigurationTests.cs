using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Monad;

internal sealed class BinderConfigurationTests
{
    [Test]
    public void TestAddBinding()
    {
        var services = Substitute.For<IServiceCollection>();
        var configuration = new BinderConfiguration(services);
        configuration.AddBinding<ComponentBase, int, FakeBinding>();
        services.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(Binding<ComponentBase, int>) && d.Lifetime == ServiceLifetime.Scoped));
    }

    private sealed class FakeBinding : Binding<ComponentBase, int>
    {
        protected override void Apply(Bindable<ComponentBase> bindable, Expression<Func<int>> expression)
            => throw new NotSupportedException();
    }
}
