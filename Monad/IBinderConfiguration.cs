using Microsoft.AspNetCore.Components;

namespace Monad;

public interface IBinderConfiguration
{
    [Description("Registers a binding.")]
    IBinderConfiguration AddBinding<TComponent, TValue, TBinding>() where TComponent : IComponent where TBinding : Binding<TComponent, TValue>;
}
