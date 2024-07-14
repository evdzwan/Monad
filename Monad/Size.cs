namespace Monad;

public sealed class Size
{
    public Size(string value) : this(double.NaN, SizeUnit.Custom)
    {
        Value = value;
    }

    private Size(double magnitude, SizeUnit unit)
    {
        Magnitude = magnitude;
        Unit = unit;
    }

    public static Size Auto { get; } = new(double.NaN, SizeUnit.Auto);

    public double Magnitude { get; }

    public SizeUnit Unit { get; }

    public string? Value { get; }

    public static Size Exact(double sizeInPixels)
        => new(sizeInPixels, SizeUnit.Exact);

    public static Size Fill(double factor = 1)
        => new(factor, SizeUnit.Fill);

    public override string ToString()
        => $"{Magnitude} {Unit}";
}
