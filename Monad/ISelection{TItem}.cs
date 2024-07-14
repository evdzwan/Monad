namespace Monad;

public interface ISelection<TItem>
{
    internal bool Multiple { get; }

    internal ICollection<TItem> Target { get; }

    void Activate(TItem item);

    void Deactivate(TItem item);

    bool IsActive(TItem item);

    void Toggle(TItem item);
}
