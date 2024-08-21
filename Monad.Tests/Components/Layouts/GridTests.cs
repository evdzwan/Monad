using Microsoft.AspNetCore.Components.Rendering;

namespace Monad.Components.Layouts;

internal sealed class GridTests : BUnitTestContext
{
    [Test]
    public void TestContent()
    {
        var grid = RenderComponent<Grid>(builder => builder.Add(c => c.Content, "fake-content"));
        grid.MarkupMatches("""<div class="grid" style="">fake-content</div>""");
    }

    [Test]
    public void TestColumns()
    {
        var grid = RenderComponent<Grid>(builder => builder.Add(c => c.Columns, (RenderTreeBuilder b) =>
        {
            b.OpenComponent<GridColumn>(sequence: 0);
            b.CloseComponent();
            b.OpenComponent<GridColumn>(sequence: 1);
            b.AddComponentParameter(sequence: 2, nameof(GridColumn.Width), Size.Fraction(1));
            b.CloseComponent();
            b.OpenComponent<GridColumn>(sequence: 3);
            b.AddComponentParameter(sequence: 4, nameof(GridColumn.Width), Size.Fraction(2));
            b.AddComponentParameter(sequence: 5, nameof(GridColumn.Scope), Breakpoint.Large);
            b.CloseComponent();
        }));

        grid.MarkupMatches("""
            <div class="grid" style="--template-rows:;
                                     --template-columns: auto 1fr;
                                     --template-columns-sm: auto 1fr;
                                     --template-columns-md: auto 1fr;
                                     --template-columns-lg: auto 1fr 2fr" />
            """);
    }

    [Test]
    public void TestRows()
    {
        var grid = RenderComponent<Grid>(builder => builder.Add(c => c.Rows, (RenderTreeBuilder b) =>
        {
            b.OpenComponent<GridRow>(sequence: 6);
            b.CloseComponent();
            b.OpenComponent<GridRow>(sequence: 7);
            b.AddComponentParameter(sequence: 8, nameof(GridRow.Height), Size.Fraction(1));
            b.CloseComponent();
        }));

        grid.MarkupMatches("""
            <div class="grid" style="--template-rows: auto 1fr;
                                     --template-columns:;
                                     --template-columns-sm:;
                                     --template-columns-md:;
                                     --template-columns-lg:" />
            """);
    }
}
