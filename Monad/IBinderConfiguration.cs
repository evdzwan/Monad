using Microsoft.AspNetCore.Components;

namespace Monad;

public interface IBinderConfiguration
{
    IBinderConfiguration AddBinding<TComponent, TValue, TBinding>() where TComponent : IComponent where TBinding : Binding<TComponent, TValue>;
}
