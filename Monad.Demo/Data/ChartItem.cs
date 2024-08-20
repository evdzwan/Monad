namespace Monad.Data;

public sealed class ChartItem(string name, int value)
{
    public string Name { get; } = name;

    public int Value { get; set; } = value;

    public static ChartItem[] CreateRange()
        => Enumerable.Range(1, 6).Select(index => new ChartItem($"Item {index + 1}", GetRandomValue())).ToArray();

    private static int GetRandomValue()
        => Random.Shared.Next(50, 200);

    public void RandomizeValue()
        => Value = GetRandomValue();
}
