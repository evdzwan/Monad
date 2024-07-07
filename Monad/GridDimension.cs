﻿namespace Monad;

public sealed class GridDimension(string value)
{
    public static GridDimension Auto => new("auto");

    public string Value { get; } = value;

    public static GridDimension Exact(double sizeInPixels)
        => new($"{sizeInPixels}px");

    public static GridDimension Fill(int factor = 1)
        => new($"{factor}fr");

    public override string ToString()
        => Value;
}
