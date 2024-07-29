namespace Monad.Components.Controls;

internal sealed class EditorTests : BUnitTestContext
{
    [Test]
    public void TestId()
    {
        var editor = RenderComponent<Editor<string>>(builder => builder.Add(c => c.Id, "fake-id"));
        editor.MarkupMatches("""<div class="editor"><input id="fake-id" type="text" /></div>""");
    }

    [Test]
    public void TestType()
    {
        var multiLineEditor = RenderComponent<Editor<string>>(builder => builder.Add(c => c.Type, EditorType.MultiLine));
        multiLineEditor.MarkupMatches("""<div class="editor"><textarea></textarea></div>""");

        var numberEditor = RenderComponent<Editor<int>>();
        numberEditor.MarkupMatches("""<div class="editor"><input type="number" /></div>""");

        var textEditor = RenderComponent<Editor<string>>();
        textEditor.MarkupMatches("""<div class="editor"><input type="text" /></div>""");
    }

    [Test]
    public void TestValue()
    {
        var editor = RenderComponent<Editor<string>>(builder => builder.Add(c => c.Value, "fake-value"));
        editor.MarkupMatches("""<div class="editor"><input type="text" value="fake-value" /></div>""");
    }

    [Test]
    public void TestValueChanged()
    {
        var context = new Context { Value = 37 };
        var valueChanged = Substitute.For<Action<int>>();

        var editor = RenderComponent<Editor<int>>(builder => builder.Bind(c => c.Value, context.Value, valueChanged, () => context.Value));
        var element = editor.Find("input");
        element.Change(42);

        valueChanged.Received().Invoke(42);
    }

    [Test]
    public void TestValueExpression()
    {
        var context = new Context { Value = 37 };
        var editor = RenderComponent<Editor<int>>(builder => builder.Bind(c => c.Value, context.Value, Substitute.For<Action<int>>(), () => context.Value));
        editor.MarkupMatches("""<div class="editor"><input type="number" min="0" max="42" value="37" /></div>""");
    }

    private sealed class Context
    {
        [System.ComponentModel.DataAnnotations.Range(minimum: 0, maximum: 42)]
        public int Value { get; set; }
    }
}
