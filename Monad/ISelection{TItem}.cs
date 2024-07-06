namespace Monad;

public interface ISelection<TItem>
{
    ICollection<TItem> ActiveItems { get; }

    bool Multiple { get; }

    void Activate(TItem item);

    void Deactivate(TItem item);

    bool IsActive(TItem item);

    void Toggle(TItem item);
}
