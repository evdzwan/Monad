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

    public override string ToString()
        => string.Join(';', _attributes);

    public static implicit operator string(StyleList list)
        => list.ToString();
}
