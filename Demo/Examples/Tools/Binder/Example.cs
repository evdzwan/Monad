// binding definition (.net core apps); note that IBinderConfiguration is registered as a singleton
services.AddBinder(configuration =>
{
    // register all available bindings here; all bindings are registered as scoped services
    configuration.AddBinding<MyComponent, string, MyComponentStringBinding>();
});

// binding example
class MyComponentStringBinding : Binding<MyComponent, string>
{
    protected override void Apply(Bindable<MyComponent> bindable, Expression<Func<string>> expression)
    {
        // use expression helpers (as extension methods) to analyze the provided expression
        var context = expression.GetContext();
        var property = expression.GetPropertyInfo();

        // set component parameters by using bindable
        bindable.Set(c => c.Range, property.GetCustomAttribute<RangeAttribute>().Select(r => (r.Minimum, r.Maximum)));
        bindable.Set(c => c.Required, property.GetCustomAttribute<RequiredAttribute>() is not null);
    }
}

// usage example; note that IBinder is registered as a scoped service
class MyComponent : ComponentBase
{
    [Inject]
    private IBinder Binder { get; set; } = default!;

    protected override Task OnInitializedAsync()
        => Binder.Bind(this, ValueExpression);
}