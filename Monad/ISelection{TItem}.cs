namespace Monad;

public interface ISelection<TItem>
{
    internal bool Multiple { get; }

    internal ICollection<TItem> Target { get; }

    [Description("Ensure that item is selected.")]
    void Activate(TItem item);

    [Description("Ensure that item is not selected.")]
    void Deactivate(TItem item);

    [Description("Returns <code>true</code> when item is selected.")]
    bool IsActive(TItem item);

    [Description("Toggle selected state.")]
    void Toggle(TItem item);
}
