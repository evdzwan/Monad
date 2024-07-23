namespace Monad;

public sealed class StyleList
{
    private readonly List<string> _attributes = [];

    [Description("Adds an additional value to the list.")]
    public StyleList Add(string name, string? value, bool condition = true)
    {
        if (condition)
        {
            _attributes.Add($"{name}:{value}");
        }

        return this;
    }

    [Description("Create a new list with an initial value.")]
    public static StyleList Create(string name, string? value, bool condition = true)
        => new StyleList().Add(name, value, condition);

    [Description("String representation of the list.")]
    public override string ToString()
        => string.Join(';', _attributes);

    public static implicit operator string(StyleList list)
        => list.ToString();
}
