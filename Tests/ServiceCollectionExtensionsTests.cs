using Microsoft.Extensions.DependencyInjection;

namespace Monad;

internal sealed class ServiceCollectionExtensionsTests
{
    [Test]
    public void TestAddBinder()
    {
        var configure = Substitute.For<Action<IBinderConfiguration>>();
        var services = Substitute.For<IServiceCollection>();
        services.AddBinder(configure);

        configure.Received().Invoke(Arg.Any<IBinderConfiguration>());
        services.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(IBinderConfiguration) && d.Lifetime == ServiceLifetime.Singleton));
        services.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(IBinder) && d.Lifetime == ServiceLifetime.Scoped));
    }

    [Test]
    public void TestAddThemes()
    {
        var services = Substitute.For<IServiceCollection>();
        services.AddThemes();
     
        services.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(IThemeManager) && d.Lifetime == ServiceLifetime.Scoped));
    }
}
