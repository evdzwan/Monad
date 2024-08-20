namespace Monad;

public sealed class StyleList
{
    private readonly List<string> _attributes = [];

    public StyleList Add(string name, string? value, bool condition = true)
    {
        if (condition)
        {
            _attributes.Add($"{name}:{value}");
        }

        return this;
    }

    public static StyleList Create(string name, string? value, bool condition = true)
        => new StyleList().Add(name, value, condition);

    public static StyleList Create(IReadOnlyDictionary<string, object?> unhandledAttributes)
    {
        var list = new StyleList();
        if (unhandledAttributes.TryGetValue("style", out var value) && value is string { Length: > 0 } attributes)
        {
            foreach (var attribute in attributes.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(attribute => attribute.Split(':', StringSplitOptions.TrimEntries)))
            {
                list = list.Add(attribute[0], attribute[1], condition: true);
            }
        }

        return list;
    }

    public override string ToString()
        => string.Join(';', _attributes);

    public static implicit operator string(StyleList list)
        => list.ToString();
}
