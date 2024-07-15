using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Monad.Components.Controls;

internal sealed class DataGridTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var dataGrid = RenderComponent<DataGrid<int>>(builder => builder.AddChildContent(b =>
        {
            b.OpenComponent<DataGridTemplateColumn<int>>(sequence: 0);
            b.AddComponentParameter(sequence: 1, nameof(DataGridTemplateColumn<int>.Title), "first-title");
            b.CloseComponent();

            b.OpenComponent<DataGridTemplateColumn<int>>(sequence: 2);
            b.AddComponentParameter(sequence: 3, nameof(DataGridTemplateColumn<int>.Title), "second-title");
            b.AddComponentParameter(sequence: 4, nameof(DataGridTemplateColumn<int>.Width), Size.Fill());
            b.CloseComponent();
        }));

        dataGrid.MarkupMatches("""
            <div class="data-grid">
                <div class="data-grid-column" style="width:auto"></div>
                <div class="data-grid-column" style="width:calc(1 / 1 * 100%)"></div>
                <div class="data-grid-header">
                    <div class="data-grid-cell">first-title</div>
                    <div class="data-grid-cell">second-title</div>
                </div>
            </div>
            """);
    }

    [Test]
    public void TestItems()
    {
        var dataGrid = RenderComponent<DataGrid<int>>(builder => builder.AddChildContent(b =>
        {
            b.OpenComponent<DataGridTemplateColumn<int>>(sequence: 0);
            b.AddComponentParameter(sequence: 1, nameof(DataGridTemplateColumn<int>.Title), "fake-title");
            b.AddComponentParameter(sequence: 2, nameof(DataGridTemplateColumn<int>.ChildContent), new RenderFragment<int>(v => cb => cb.AddContent(sequence: 0, v.ToString())));
            b.CloseComponent();
        }).Add(c => c.Items, [37, 42]));

        dataGrid.MarkupMatches("""
            <div class="data-grid">
                <div class="data-grid-column" style="width:auto"></div>
                <div class="data-grid-header">
                    <div class="data-grid-cell">fake-title</div>
                </div>
                <div class="data-grid-row">
                    <div class="data-grid-cell">37</div>
                </div>
                <div class="data-grid-row">
                    <div class="data-grid-cell">42</div>
                </div>
            </div>
            """);
    }

    [Test]
    public void TestItemsProvider()
    {
        var itemsProvider = new DataGridItemsProvider<int>(request => ValueTask.FromResult(new DataGridItemsProviderResult<int>([], totalItemCount: 0)));
        var dataGrid = RenderComponent<DataGrid<int>>(builder => builder.Add(c => c.ItemsProvider, itemsProvider)
                                                                        .Add(c => c.Virtualize, true));

        var virtualize = dataGrid.FindComponent<Virtualize<int>>();
        Assert.That(virtualize.Instance.ItemsProvider, Is.Not.Null);
    }

    [Test]
    public void TestOverscanCount()
    {
        var dataGrid = RenderComponent<DataGrid<int>>(builder => builder.Add(c => c.Items, [37, 42])
                                                                        .Add(c => c.OverscanCount, 1337)
                                                                        .Add(c => c.Virtualize, true));

        var virtualize = dataGrid.FindComponent<Virtualize<int>>();
        Assert.That(virtualize.Instance.OverscanCount, Is.EqualTo(1337));
    }

    [Test]
    public void TestVirtualize()
    {
        var nonVirtualizingDataGrid = RenderComponent<DataGrid<int>>(builder => builder.Add(c => c.Virtualize, false));
        Assert.That(nonVirtualizingDataGrid.HasComponent<Virtualize<int>>(), Is.False);

        var virtualizingDataGrid = RenderComponent<DataGrid<int>>(builder => builder.Add(c => c.Items, [37, 42])
                                                                                    .Add(c => c.Virtualize, true));

        Assert.That(virtualizingDataGrid.HasComponent<Virtualize<int>>(), Is.True);
    }
}
