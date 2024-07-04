namespace Monad;

public sealed class GridDimension
{
    private GridDimension(string value)
        => Value = value;

    internal string Value { get; }

    public static GridDimension Auto
        => new("auto");

    public static GridDimension Exact(int sizeInPixels)
        => new($"{sizeInPixels}px");

    public static GridDimension Fill(int factor = 1)
        => new($"{factor}fr");

    public override string ToString()
        => Value;
}
