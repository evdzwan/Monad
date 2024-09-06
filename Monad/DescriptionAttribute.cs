namespace Monad;

[AttributeUsage(AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Property)]
public sealed class DescriptionAttribute(string description) : Attribute
{
    public string Description { get; } = description;
}
