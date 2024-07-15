namespace Monad;

internal sealed class SizeTests
{
    [Test]
    public void TestAuto()
    {
        var size = Size.Auto;
        Assert.Multiple(() =>
        {
            Assert.That(size.Magnitude, Is.EqualTo(double.NaN));
            Assert.That(size.Unit, Is.EqualTo(SizeUnit.Auto));
        });
    }

    [Test]
    public void TestMagnitude()
    {
        var size = Size.Fill();
        Assert.That(size.Magnitude, Is.EqualTo(1));

        size = new("auto");
        Assert.That(size.Magnitude, Is.EqualTo(double.NaN));
    }

    [Test]
    public void TestUnit()
    {
        var size = Size.Fill();
        Assert.That(size.Unit, Is.EqualTo(SizeUnit.Fill));

        size = new("auto");
        Assert.That(size.Unit, Is.EqualTo(SizeUnit.Custom));
    }

    [Test]
    public void TestValue()
    {
        var size = Size.Fill();
        Assert.That(size.Value, Is.Null);

        size = new("auto");
        Assert.That(size.Value, Is.EqualTo("auto"));
    }

    [Test]
    public void TestExact()
    {
        var size = Size.Exact(sizeInPixels: 42);
        Assert.Multiple(() =>
        {
            Assert.That(size.Magnitude, Is.EqualTo(42));
            Assert.That(size.Unit, Is.EqualTo(SizeUnit.Exact));
        });
    }

    [Test]
    public void TestFill()
    {
        var size = Size.Fill();
        Assert.Multiple(() =>
        {
            Assert.That(size.Magnitude, Is.EqualTo(1));
            Assert.That(size.Unit, Is.EqualTo(SizeUnit.Fill));
        });
    }

    [Test]
    public void TestToString()
    {
        var size = new Size("42em");
        Assert.That(size.ToString(), Is.EqualTo("42em"));

        size = Size.Fill(factor: 2);
        Assert.That(size.ToString(), Is.EqualTo($"2 {SizeUnit.Fill}"));
    }
}
