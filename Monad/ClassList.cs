namespace Monad;

public sealed class ClassList
{
    private readonly List<string> _classNames = [];

    public ClassList Add(string className, bool condition = true)
    {
        if (condition)
        {
            _classNames.Add(className);
        }

        return this;
    }

    public static ClassList Create(string className, bool condition = true)
        => new ClassList().Add(className, condition);

    public static ClassList Create(IReadOnlyDictionary<string, object?> unhandledAttributes)
    {
        var list = new ClassList();
        if (unhandledAttributes.TryGetValue("class", out var value) && value is string { Length: > 0 } classNames)
        {
            foreach (var className in classNames.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                list = list.Add(className, condition: true);
            }
        }

        return list;
    }

    public override string ToString()
        => string.Join(' ', _classNames);

    public static implicit operator string(ClassList list)
        => list.ToString();
}
