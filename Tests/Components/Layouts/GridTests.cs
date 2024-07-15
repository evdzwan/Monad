namespace Monad.Components.Layouts;

internal sealed class GridTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var stack = RenderComponent<Grid>(builder => builder.AddChildContent(b =>
        {
            b.OpenComponent<GridColumn>(sequence: 0);
            b.CloseComponent();

            b.OpenComponent<GridColumn>(sequence: 1);
            b.CloseComponent();

            b.OpenComponent<GridRow>(sequence: 2);
            b.CloseComponent();

            b.OpenComponent<GridRow>(sequence: 3);
            b.CloseComponent();

            b.OpenComponent<GridCell>(sequence: 4);
            b.CloseComponent();

            b.OpenComponent<GridCell>(sequence: 5);
            b.AddComponentParameter(sequence: 6, nameof(GridCell.X), 1);
            b.CloseComponent();

            b.OpenComponent<GridCell>(sequence: 7);
            b.AddComponentParameter(sequence: 8, nameof(GridCell.SpanX), 2);
            b.AddComponentParameter(sequence: 9, nameof(GridCell.Y), 1);
            b.CloseComponent();
        }));

        stack.MarkupMatches("""
            <div class="grid" style="grid-template-columns: auto auto;grid-template-rows:auto auto">
                <div class="grid-cell" style="grid-column:1 / span 1;grid-row:1 / span 1"></div>
                <div class="grid-cell" style="grid-column:2 / span 1;grid-row:1 / span 1"></div>
                <div class="grid-cell" style="grid-column:1 / span 2;grid-row:2 / span 1"></div>
            </div>
            """);
    }
}
