namespace Monad;

public readonly record struct DataGridItemsProviderRequest(int StartIndex, int Count, CancellationToken CancellationToken);
