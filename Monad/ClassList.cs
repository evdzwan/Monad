namespace Monad;

public sealed class ClassList
{
    private readonly List<string> _classNames = [];

    [Description("Adds an additional value to the list.")]
    public ClassList Add(string className, bool condition = true)
    {
        if (condition)
        {
            _classNames.Add(className);
        }

        return this;
    }

    [Description("Create a new list with an initial value.")]
    public static ClassList Create(string className, bool condition = true)
        => new ClassList().Add(className, condition);

    [Description("String representation of the list.")]
    public override string ToString()
        => string.Join(' ', _classNames);

    public static implicit operator string(ClassList list)
        => list.ToString();
}
