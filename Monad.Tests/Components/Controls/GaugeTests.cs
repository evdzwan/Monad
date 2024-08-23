using AngleSharp.Css.Dom;

namespace Monad.Components.Controls;

internal sealed class GaugeTests : BUnitTestContext
{
    [Test]
    public void TestMaximum()
    {
        var gauge = RenderComponent<Gauge>(builder => builder.Add(c => c.Maximum, 90));
        var entity = gauge.Find(".gauge-entity");

        Assert.That(entity.GetStyle().GetPropertyValue("--value-max"), Is.EqualTo("90"));
    }

    [Test]
    public void TestMinimum()
    {
        var gauge = RenderComponent<Gauge>(builder => builder.Add(c => c.Minimum, 10));
        var entity = gauge.Find(".gauge-entity");

        Assert.That(entity.GetStyle().GetPropertyValue("--value-min"), Is.EqualTo("10"));
    }

    [Test]
    public void TestType()
    {
        var gauge = RenderComponent<Gauge>();
        Assert.Multiple(() =>
        {
            Assert.That(gauge.FindAll(".gauge.circle"), Is.Not.Empty);
            Assert.That(gauge.FindAll(".gauge.ring"), Is.Empty);
        });

        gauge.SetParametersAndRender(builder => builder.Add(c => c.Type, GaugeType.Ring));
        Assert.Multiple(() =>
        {
            Assert.That(gauge.FindAll(".gauge.circle"), Is.Empty);
            Assert.That(gauge.FindAll(".gauge.ring"), Is.Not.Empty);
        });
    }

    [Test]
    public void TestValue()
    {
        var gauge = RenderComponent<Gauge>(builder => builder.Add(c => c.Value, 42));
        var entity = gauge.Find(".gauge-entity");

        Assert.That(entity.GetStyle().GetPropertyValue("--value"), Is.EqualTo("42"));
    }
}
