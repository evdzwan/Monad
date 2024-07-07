namespace Monad;

public sealed class ClassList
{
    private readonly List<string> _classNames = [];

    public ClassList Add(string className, bool condition)
    {
        if (condition)
        {
            _classNames.Add(className);
        }

        return this;
    }

    public ClassList AddIfNotEmpty(string? className)
        => Add(className!, className is { Length: > 0 });

    public static ClassList Create(string className, bool condition = true)
        => new ClassList().Add(className, condition);

    public override string ToString()
        => string.Join(' ', _classNames);

    public static implicit operator string(ClassList list)
        => list.ToString();
}
