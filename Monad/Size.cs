using System.Globalization;

namespace Monad;

public sealed class Size(string value)
{
    public static Size Auto { get; } = new("auto");

    public string Value { get; } = value;

    public static Size Fraction(double fraction)
        => new($"{fraction.ToString(CultureInfo.InvariantCulture)}fr");

    public static Size Percentage(double percentage)
        => new($"{percentage.ToString(CultureInfo.InvariantCulture)}%");

    public static Size Pixels(double pixels)
        => new($"{pixels.ToString(CultureInfo.InvariantCulture)}px");

    public override string ToString()
        => Value;
}
