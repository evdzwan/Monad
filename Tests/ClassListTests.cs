namespace Monad;

internal sealed class ClassListTests
{
    [Test]
    public void TestAdd()
    {
        var classList = ClassList.Create("first-class")
                                 .Add("second-class")
                                 .Add("third-class", condition: false);

        Assert.That(classList.ToString(), Is.EqualTo("first-class second-class"));
    }

    [Test]
    public void TestCreate()
        => Assert.That(ClassList.Create("fake-class"), Is.Not.Null);

    [Test]
    public void TestToString()
    {
        var classList = ClassList.Create("fake-class");
        Assert.Multiple(() =>
        {
            Assert.That(classList.ToString(), Is.EqualTo("fake-class"));
            Assert.That((string)classList, Is.EqualTo("fake-class"));
        });
    }
}
