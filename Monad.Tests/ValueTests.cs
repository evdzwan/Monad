namespace Monad;

internal sealed class ValueTests
{
    [Test]
    public void TestExchange()
    {
        var value = "fake-value";
        Value.Exchange(ref value, "new-value");
        Assert.That(value, Is.EqualTo("new-value"));

        value = "fake-value";
        var changed = Substitute.For<Action>();
        Value.Exchange(ref value, "fake-value", changed);
        changed.DidNotReceive().Invoke();

        value = "fake-value";
        var prevValue = Value.Exchange(ref value, "fake-value");
        Assert.That(prevValue, Is.Null);

        value = "fake-value";
        changed = Substitute.For<Action>();
        Value.Exchange(ref value, "new-value", changed);
        changed.Received().Invoke();

        value = "value";
        var changedWithSingleParameter = Substitute.For<Action<string>>();
        Value.Exchange(ref value, "new-value", changedWithSingleParameter);
        changedWithSingleParameter.Received().Invoke("new-value");

        value = "value";
        var changedWithMultipleParameters = Substitute.For<Action<string, string>>();
        Value.Exchange(ref value, "new-value", changedWithMultipleParameters);
        changedWithMultipleParameters.Received().Invoke("value", "new-value");

        value = "fake-value";
        prevValue = Value.Exchange(ref value, "new-value");
        Assert.That(prevValue, Is.EqualTo("fake-value"));
    }
}
