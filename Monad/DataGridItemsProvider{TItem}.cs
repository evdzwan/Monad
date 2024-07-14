namespace Monad;

public delegate ValueTask<DataGridItemsProviderResult<TItem>> DataGridItemsProvider<TItem>(DataGridItemsProviderRequest request);
