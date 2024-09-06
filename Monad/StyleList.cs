using System.Globalization;

namespace Monad;

public sealed class StyleList
{
    private readonly List<string> _attributes = [];

    [Description("Adds an additional value to the list.")]
    public StyleList Add(string name, object? value, bool condition = true)
    {
        if (condition)
        {
            _attributes.Add($"{name}:{value switch
            {
                double doubleValue => doubleValue.ToString(CultureInfo.InvariantCulture),
                string stringValue => stringValue,
                _ => value?.ToString()
            }}");
        }

        return this;
    }

    [Description("Creates a new list with an initial value.")]
    public static StyleList Create(string name, object? value, bool condition = true)
        => new StyleList().Add(name, value, condition);

    [Description("Creates a new list using an unhandled attributes dictionary.")]
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

    [Description("String representation of the list.")]
    public override string ToString()
        => string.Join(';', _attributes);

    public static implicit operator string(StyleList list)
        => list.ToString();
}
