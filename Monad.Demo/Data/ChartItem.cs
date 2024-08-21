namespace Monad.Data;

internal sealed class ChartItem(string name, int value)
{
    public string Name { get; } = name;

    public int Value { get; private set; } = value;

    public static ChartItem[] CreateDemoRange(int count)
        => Enumerable.Range(1, count).Select(index => new ChartItem($"Item {index}", GetRandomValue())).ToArray();

    private static int GetRandomValue()
        => Random.Shared.Next(50, 200);

    public void RandomizeValue()
        => Value = GetRandomValue();
}
