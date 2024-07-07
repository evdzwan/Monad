namespace Monad;

public sealed class StyleList
{
    private readonly List<string> _attributes = [];

    public StyleList Add(string name, string? value)
    {
        _attributes.Add($"{name}:{value}");
        return this;
    }

    public static StyleList Create(string name, string? value)
        => new StyleList().Add(name, value);

    public override string ToString()
        => string.Join(';', _attributes);

    public static implicit operator string(StyleList list)
        => list.ToString();
}
