namespace Monad;

public interface ISelection<TItem>
{
    internal bool Multiple { get; }

    internal ICollection<TItem> Target { get; }

    [Description("Adds <code>item</code> to target selection.")]
    void Activate(TItem item);

    [Description("Removes <code>item</code> from target selection.")]
    void Deactivate(TItem item);

    [Description("Checks wether <code>item</code> exists in target selection.")]
    bool IsActive(TItem item);

    [Description("Adds <code>item</code> when not already active; removes it otherwise.")]
    void Toggle(TItem item);
}
