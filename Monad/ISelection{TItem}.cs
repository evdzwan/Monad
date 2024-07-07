namespace Monad;

public interface ISelection<TItem>
{
    void Activate(TItem item);

    void Deactivate(TItem item);

    bool IsActive(TItem item);

    void Toggle(TItem item);
}
