namespace Monad;

internal sealed class StyleListTests
{
    [Test]
    public void TestAdd()
    {
        var styleList = StyleList.Create("first-prop", "first-value")
                                 .Add("second-prop", "second-value")
                                 .Add("third-prop", "third-value", condition: false);

        Assert.That(styleList.ToString(), Is.EqualTo("first-prop:first-value;second-prop:second-value"));
    }

    [Test]
    public void TestCreate()
    {
        Assert.That(StyleList.Create("fake-prop", "fake-value"), Is.Not.Null);

        var unhandledAttributes = Substitute.For<IReadOnlyDictionary<string, object?>>();
        unhandledAttributes.TryGetValue("style", out Arg.Any<object?>()).Returns(info =>
        {
            info[1] = "fake-attribute:fake-value";
            return true;
        });

        Assert.That(StyleList.Create(unhandledAttributes).ToString(), Is.EqualTo("fake-attribute:fake-value"));
    }

    [Test]
    public void TestToString()
    {
        var styleList = StyleList.Create("fake-prop", "fake-value");
        Assert.Multiple(() =>
        {
            Assert.That(styleList.ToString(), Is.EqualTo("fake-prop:fake-value"));
            Assert.That((string)styleList, Is.EqualTo("fake-prop:fake-value"));
        });
    }
}
