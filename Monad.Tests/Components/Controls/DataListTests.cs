using Microsoft.AspNetCore.Components;

namespace Monad.Components.Controls;

internal sealed class DataListTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var dataList = RenderComponent<DataList<int>>(builder => builder.Add(c => c.ChildContent, _ => "fake-content"));
        dataList.MarkupMatches($"""
            fake-content
            <datalist id="{dataList.Instance.Id}" />
            """);
    }

    [Test]
    public void TestId()
    {
        var firstDataList = RenderComponent<DataList<int>>();
        Assert.That(firstDataList.Instance.Id, Is.Not.Empty);

        var secondDataList = RenderComponent<DataList<int>>();
        Assert.That(secondDataList.Instance.Id, Is.Not.Empty);
        Assert.That(secondDataList.Instance.Id, Is.Not.EqualTo(firstDataList.Instance.Id));

        var thirdDataList = RenderComponent<DataList<int>>(builder => builder.Add(c => c.ChildContent, _ => builder =>
        {
            builder.OpenComponent<ChildComponent>(sequence: 0);
            builder.CloseComponent();
        }).Add(c => c.Id, "fake-id"));

        Assert.That(thirdDataList.FindComponent<ChildComponent>().Instance.DataListProvider, Is.Not.Null);
        Assert.That(thirdDataList.FindComponent<ChildComponent>().Instance.DataListProvider.DataListId, Is.EqualTo("fake-id"));
    }

    [Test]
    public void TestItems()
    {
        var dataList = RenderComponent<DataList<int>>(builder => builder.Add(c => c.Items, [1, 2, 3]));
        dataList.MarkupMatches($"""
            <datalist id="{dataList.Instance.Id}">
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
            </datalist>
            """);
    }

    [Test]
    public void TestProvideItemText()
    {
        var dataList = RenderComponent<DataList<int>>(builder => builder.Add(c => c.Items, [1, 2, 3])
                                                                        .Add(c => c.ProvideItemText, v => $"fake-text-{v}"));

        dataList.MarkupMatches($"""
            <datalist id="{dataList.Instance.Id}">
                <option value="1">fake-text-1</option>
                <option value="2">fake-text-2</option>
                <option value="3">fake-text-3</option>
            </datalist>
            """);
    }

    [Test]
    public void TestProvideItemValue()
    {
        var dataList = RenderComponent<DataList<int>>(builder => builder.Add(c => c.Items, [1, 2, 3])
                                                                        .Add(c => c.ProvideItemValue, v => $"fake-value-{v}"));

        dataList.MarkupMatches($"""
            <datalist id="{dataList.Instance.Id}">
                <option value="fake-value-1">1</option>
                <option value="fake-value-2">2</option>
                <option value="fake-value-3">3</option>
            </datalist>
            """);
    }

    private sealed class ChildComponent : ComponentBase
    {
        [CascadingParameter]
        internal IDataListProvider? DataListProvider { get; set; }
    }
}
