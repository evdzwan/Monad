namespace Monad;

internal sealed class Selection<TItem>(ICollection<TItem> activeItems, bool multiple) : ISelection<TItem>
{
    public ICollection<TItem> ActiveItems { get; } = activeItems;

    public bool Multiple { get; } = multiple;

    public void Activate(TItem item)
    {
        if (!IsActive(item))
        {
            if (!Multiple)
            {
                ActiveItems.Clear();
            }

            ActiveItems.Add(item);
        }
    }

    public void Deactivate(TItem item)
        => ActiveItems.Remove(item);

    public bool IsActive(TItem item)
        => ActiveItems.Contains(item);

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
