using AngleSharp.Css.Dom;

namespace Monad.Components.Controls;

internal sealed class ChartTests : BUnitTestContext
{
    [Test]
    public void TestItems()
    {
        var chart = RenderComponent<Chart<int>>(builder => builder.Add(c => c.Items, []));
        Assert.That(chart.FindAll(".chart-entity"), Is.Empty);

        chart.SetParametersAndRender(builder => builder.Add(c => c.Items, [1, 2, 3]));
        Assert.That(chart.FindAll(".chart-entity"), Has.Count.EqualTo(3));
    }

    [Test]
    public void TestItemValue()
    {
        var chart = RenderComponent<Chart<int>>(builder => builder.Add(c => c.Items, [1]));
        var entity = chart.Find(".chart-entity");
        Assert.That(entity.GetStyle().GetPropertyValue("--value"), Is.EqualTo("1"));

        chart.SetParametersAndRender(builder => builder.Add(c => c.ItemValue, v => 42));
        entity = chart.Find(".chart-entity");
        Assert.That(entity.GetStyle().GetPropertyValue("--value"), Is.EqualTo("42"));
    }

    [Test]
    public void TestType()
    {
        var chart = RenderComponent<Chart<int>>(builder => builder.Add(c => c.Items, [1, 2, 3]));
        Assert.Multiple(() =>
        {
            Assert.That(chart.FindAll(".chart.area"), Is.Not.Empty);
            Assert.That(chart.FindAll(".chart.bar"), Is.Empty);
        });

        chart.SetParametersAndRender(builder => builder.Add(c => c.Type, ChartType.Bar));
        Assert.Multiple(() =>
        {
            Assert.That(chart.FindAll(".chart.area"), Is.Empty);
            Assert.That(chart.FindAll(".chart.bar"), Is.Not.Empty);
        });
    }
}
