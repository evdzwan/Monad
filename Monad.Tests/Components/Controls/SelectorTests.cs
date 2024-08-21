namespace Monad.Components.Controls;

internal sealed class SelectorTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var selector = RenderComponent<Selector<int>>(builder => builder.Add(c => c.ChildContent, _ => "fake-content"));
        selector.MarkupMatches("fake-content");
    }

    [Test]
    public void TestMultiple()
    {
        RenderComponent<Selector<int>>(builder =>
        {
            builder.Add(c => c.Multiple, false);
            builder.Add(c => c.ChildContent, selection =>
            {
                selection.Toggle(1);
                Assert.That(selection.IsActive(1), Is.True);

                selection.Toggle(2);
                Assert.Multiple(() =>
                {
                    Assert.That(selection.IsActive(1), Is.False);
                    Assert.That(selection.IsActive(2), Is.True);
                });

                return "fake-content";
            });
        });

        RenderComponent<Selector<int>>(builder =>
        {
            builder.Add(c => c.Multiple, true);
            builder.Add(c => c.ChildContent, selection =>
            {
                selection.Toggle(1);
                Assert.That(selection.IsActive(1), Is.True);

                selection.Toggle(2);
                Assert.Multiple(() =>
                {
                    Assert.That(selection.IsActive(1), Is.True);
                    Assert.That(selection.IsActive(2), Is.True);
                });

                return "fake-content";
            });
        });
    }

    [Test]
    public void TestSelection()
    {
        RenderComponent<Selector<int>>(builder =>
        {
            builder.Add(c => c.Multiple, false);
            builder.Add(c => c.ChildContent, selection =>
            {
                Assert.That(selection, Is.Not.Null);
                return "fake-content";
            });
        });
    }
}
