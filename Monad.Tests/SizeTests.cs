namespace Monad;

internal sealed class SizeTests
{
    [Test]
    public void TestAuto()
    {
        var size = Size.Auto;
        Assert.That(size.Value, Is.EqualTo("auto"));
    }

    [Test]
    public void TestFraction()
    {
        var size = Size.Fraction(1.2);
        Assert.That(size.Value, Is.EqualTo("1.2fr"));
    }

    [Test]
    public void TestPercentage()
    {
        var size = Size.Percentage(24.8);
        Assert.That(size.Value, Is.EqualTo("24.8%"));
    }

    [Test]
    public void TestPixels()
    {
        var size = Size.Pixels(4.2);
        Assert.That(size.Value, Is.EqualTo("4.2px"));
    }

    [Test]
    public void TestToString()
    {
        var size = new Size("42em");
        Assert.That(size.ToString(), Is.EqualTo("42em"));
    }

    [Test]
    public void TestValue()
    {
        var size = new Size("42em");
        Assert.That(size.Value, Is.EqualTo("42em"));
    }
}
