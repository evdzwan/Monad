namespace Monad;

internal sealed class Selection<TItem>(ICollection<TItem> target, bool multiple) : ISelection<TItem>
{
    public void Activate(TItem item)
    {
        if (!IsActive(item))
        {
            if (!multiple)
            {
                target.Clear();
            }

            target.Add(item);
        }
    }

    public void Deactivate(TItem item)
        => target.Remove(item);

    public bool IsActive(TItem item)
        => target.Contains(item);

    public void Toggle(TItem item)
    {
        if (IsActive(item))
        {
            Deactivate(item);
        }
        else
        {
            Activate(item);
        }
    }
}
