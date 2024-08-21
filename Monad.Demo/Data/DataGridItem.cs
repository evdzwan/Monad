namespace Monad.Data;

internal sealed class DataGridItem(int id, string name, int value)
{
    public int Id { get; } = id;

    public string Name { get; } = name;

    public int Value { get; private set; } = value;

    public static DataGridItem[] CreateDemoRange(int count)
        => Enumerable.Range(1, count).Select(index => new DataGridItem(index, $"Item {index}", GetRandomValue())).ToArray();

    private static int GetRandomValue()
        => 1 + Random.Shared.Next(0xFF);

    public void RandomizeValue()
        => Value = GetRandomValue();
}
