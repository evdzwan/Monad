namespace Monad;

internal sealed class Selection<TItem>(ICollection<TItem> target, bool multiple) : ISelection<TItem>
{
    public bool Multiple { get; } = multiple;

    public ICollection<TItem> Target { get; } = target;

    public void Activate(TItem item)
    {
        if (!IsActive(item))
        {
            if (!Multiple)
            {
                Target.Clear();
            }

            Target.Add(item);
        }
    }

    public void Deactivate(TItem item)
        => Target.Remove(item);

    public bool IsActive(TItem item)
        => Target.Contains(item);

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
