namespace Monad.Components.Controls;

internal sealed class ModalTests : BUnitTestContext
{
    [Test]
    public void TestActive()
    {
        var nonActiveModal = RenderComponent<Modal>(builder => builder.Add(c => c.Active, false));
        Assert.That(nonActiveModal.FindAll(".modal"), Is.Empty);

        var activeModal = RenderComponent<Modal>(builder => builder.Add(c => c.Active, true));
        Assert.That(activeModal.FindAll(".modal"), Is.Not.Empty);
    }

    [Test]
    public void TestActiveChanged()
    {
        var activeChanged = Substitute.For<Action<bool>>();
        var modal = RenderComponent<Modal>(builder => builder.Add(c => c.CloseOnFocusLost, true)
                                                             .Bind(c => c.Active, true, activeChanged));

        var element = modal.Find(".modal");
        element.Click();

        activeChanged.Received().Invoke(false);
    }

    [Test]
    public void TestChildContent()
    {
        var nonActiveModal = RenderComponent<Modal>(builder => builder.AddChildContent("fake-content")
                                                                      .Add(c => c.Active, false));

        nonActiveModal.MarkupMatches(string.Empty);
        var activeModal = RenderComponent<Modal>(builder => builder.AddChildContent("fake-content")
                                                                   .Add(c => c.Active, true));

        activeModal.MarkupMatches("""
            <div class="modal">
                <div class="modal-content">fake-content</div>
            </div>
            """);
    }

    [Test]
    public void TestCloseOnFocusLost()
    {
        var modalWithoutCloseOnFocusLostActiveChanged = Substitute.For<Action<bool>>();
        var modalWithoutCloseOnFocusLost = RenderComponent<Modal>(builder => builder.Add(c => c.CloseOnFocusLost, false)
                                                                                    .Bind(c => c.Active, true, modalWithoutCloseOnFocusLostActiveChanged));

        var elementWithoutCloseOnFocusLost = modalWithoutCloseOnFocusLost.Find(".modal");
        elementWithoutCloseOnFocusLost.Click();
        modalWithoutCloseOnFocusLostActiveChanged.DidNotReceive().Invoke(false);

        var modalWithCloseOnFocusLostActiveChanged = Substitute.For<Action<bool>>();
        var modalWithCloseOnFocusLost = RenderComponent<Modal>(builder => builder.Add(c => c.CloseOnFocusLost, true)
                                                                                 .Bind(c => c.Active, true, modalWithCloseOnFocusLostActiveChanged));

        var elementWithCloseOnFocusLost = modalWithCloseOnFocusLost.Find(".modal");
        elementWithCloseOnFocusLost.Click();
        modalWithCloseOnFocusLostActiveChanged.Received().Invoke(false);
    }
}
