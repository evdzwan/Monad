using Microsoft.AspNetCore.Components;

namespace Monad.Components.Controls;

internal sealed class PopOutTests : BUnitTestContext
{
    [Test]
    public void TestCollapseOnFocusLost()
    {
        var expanded = true;
        var popOut = RenderComponent<PopOut>(builder => builder.Add(c => c.CollapseOnFocusLost, true)
                                                               .Bind(c => c.Expanded, expanded, v => expanded = v));

        var element = popOut.Find("div.pop-out");
        element.FocusOut();
        Assert.That(expanded, Is.False);
    }

    [Test]
    public void TestContent()
    {
        var popOut = RenderComponent<PopOut>(builder => builder.Add(c => c.Content, "fake-content"));
        popOut.MarkupMatches(
            """
            <div class="pop-out" tabindex="-1">
                <div class="pop-out-trigger"></div>
                <div class="pop-out-content">fake-content</div>
            </div>
            """);
    }

    [Test]
    public void TestExpanded()
    {
        var collapsedPopOut = RenderComponent<PopOut>(builder => builder.Add(c => c.Expanded, false));
        collapsedPopOut.MarkupMatches(
            """
            <div class="pop-out" tabindex="-1">
                <div class="pop-out-trigger"></div>
                <div class="pop-out-content"></div>
            </div>
            """);

        var expandedPopOut = RenderComponent<PopOut>(builder => builder.Add(c => c.Expanded, true));
        expandedPopOut.MarkupMatches(
            """
            <div class="pop-out active" tabindex="-1">
                <div class="pop-out-trigger"></div>
                <div class="pop-out-content"></div>
            </div>
            """);
    }

    [Test]
    public void TestExpandedChanged()
    {
        var expandedChanged = Substitute.For<Action<bool>>();
        var popOut = RenderComponent<PopOut>(builder => builder.Add(c => c.ExpandedChanged, EventCallback.Factory.Create(this, expandedChanged)));
        
        expandedChanged.DidNotReceive().Invoke(Arg.Any<bool>());
        var element = popOut.Find("div.pop-out-trigger");
        
        element.Click(new());
        expandedChanged.Received().Invoke(true);
    }

    [Test]
    public void TestTrigger()
    {
        var popOut = RenderComponent<PopOut>(builder => builder.Add(c => c.Trigger, "fake-trigger"));
        popOut.MarkupMatches(
            """
            <div class="pop-out" tabindex="-1">
                <div class="pop-out-trigger">fake-trigger</div>
                <div class="pop-out-content"></div>
            </div>
            """);
    }
}
