namespace Monad;

internal sealed class CasingTests
{
    [Test]
    public void TestToKebabCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Casing.ToKebabCase(string.Empty), Is.EqualTo(string.Empty));
            Assert.That(Casing.ToKebabCase("FakeValue"), Is.EqualTo("fake-value"));
            Assert.That(Casing.ToKebabCase("Fake-Value"), Is.EqualTo("fake-value"));
            Assert.That(Casing.ToKebabCase("FakeVAlue"), Is.EqualTo("fake-v-alue"));
        });
    }
}
