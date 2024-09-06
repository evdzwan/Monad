using System.Globalization;

namespace Monad;

public sealed class Size(string value)
{
    [Description("Creates a new instance with value <code>auto</code>.")]
    public static Size Auto { get; } = new("auto");

    [Description("String representation of the size.")]
    public string Value { get; } = value;

    [Description("Creates a new instance with value <code>{fraction}fr</code>.")]
    public static Size Fraction(double fraction)
        => new($"{fraction.ToString(CultureInfo.InvariantCulture)}fr");

    [Description("Creates a new instance with value <code>{percentage}%</code>.")]
    public static Size Percentage(double percentage)
        => new($"{percentage.ToString(CultureInfo.InvariantCulture)}%");

    [Description("Creates a new instance with value <code>{pixels}px</code>.")]
    public static Size Pixels(double pixels)
        => new($"{pixels.ToString(CultureInfo.InvariantCulture)}px");

    [Description("Returns <code>Value</code> property.")]
    public override string ToString()
        => Value;
}
