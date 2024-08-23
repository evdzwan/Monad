using Microsoft.AspNetCore.Components;

namespace Monad.Components.Controls;

internal sealed class PopperTests : BUnitTestContext
{
    [Test]
    public void TestActive()
    {
        var collapsedPopper = RenderComponent<Popper>(builder => builder.Add(c => c.Active, false));
        collapsedPopper.MarkupMatches(
            """
            <div class="popper" tabindex="-1">
                <div class="popper-trigger"></div>
                <div class="popper-content"></div>
            </div>
            """
        );

        var expandedPopper = RenderComponent<Popper>(builder => builder.Add(c => c.Active, true));
        expandedPopper.MarkupMatches(
            """
            <div class="popper active" tabindex="-1">
                <div class="popper-trigger"></div>
                <div class="popper-content"></div>
            </div>
            """);
    }

    [Test]
    public void TestActiveChanged()
    {
        var activeChanged = Substitute.For<Action<bool>>();
        var popper = RenderComponent<Popper>(builder => builder.Add(c => c.Active, true)
                                                               .Add(c => c.CollapseOnFocusLost, true)
                                                               .Add(c => c.ActiveChanged, EventCallback.Factory.Create(this, activeChanged)));

        activeChanged.DidNotReceive().Invoke(Arg.Any<bool>());
        var element = popper.Find("div.popper");
        
        element.FocusOut();
        activeChanged.Received().Invoke(false);
    }

    [Test]
    public void TestCollapseOnFocusLost()
    {
        var active = true;
        var popper = RenderComponent<Popper>(builder => builder.Add(c => c.CollapseOnFocusLost, true)
                                                               .Bind(c => c.Active, active, v => active = v));

        var element = popper.Find("div.popper");
        element.FocusOut();
        Assert.That(active, Is.False);
    }

    [Test]
    public void TestContent()
    {
        var popper = RenderComponent<Popper>(builder => builder.Add(c => c.Content, "fake-content"));
        popper.MarkupMatches(
            """
            <div class="popper" tabindex="-1">
                <div class="popper-trigger"></div>
                <div class="popper-content">fake-content</div>
            </div>
            """);
    }

    [Test]
    public void TestTrigger()
    {
        var popper = RenderComponent<Popper>(builder => builder.Add(c => c.Trigger, "fake-trigger"));
        popper.MarkupMatches(
            """
            <div class="popper" tabindex="-1">
                <div class="popper-trigger">fake-trigger</div>
                <div class="popper-content"></div>
            </div>
            """);
    }
}
