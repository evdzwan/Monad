using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Monad.Components.Controls;

public sealed class DataGridExpressionColumn<TItem, TValue> : DataGridColumn<TItem>
{
    private Func<TItem, TValue> CompiledValue { get; set; } = default!;

    private RenderFragment<TItem>? DefaultEditContent { get; set; }

    [Parameter, EditorRequired, Description("Value expression.")]
    public required Expression<Func<TItem, TValue>> Value { get; set; }

    protected override RenderFragment<(TItem Item, bool Edit)> CreateCellContent()
    {
        return new(row => builder =>
        {
            if (row.Edit)
            {
                (EditContent ?? DefaultEditContent)?.Invoke(row.Item)(builder);
            }
            else
            {
                builder.AddContent(sequence: 0, CompiledValue(row.Item));
            }
        });
    }

    protected override RenderFragment CreateHeaderContent()
        => builder => builder.AddContent(sequence: 0, Title ?? (Value.Body is MemberExpression me ? me.Member.Name : null));

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        var prevValue = Value;
        await base.SetParametersAsync(parameters);
        if (Value != prevValue)
        {
            CompiledValue = Value.Compile();
            DefaultEditContent = item => builder =>
            {
                builder.OpenComponent<Editor<TValue>>(sequence: 0);
                builder.AddComponentParameter(sequence: 1, nameof(Editor<TValue>.Value), CompiledValue(item));
                builder.AddComponentParameter(sequence: 2, nameof(Editor<TValue>.ValueChanged), EventCallback.Factory.Create<TValue>(this, SetValue));
                //builder.AddComponentParameter(sequence: 3, nameof(Editor<TValue>.ValueExpression), Value);
                builder.CloseComponent();
            };
        }
    }

    private void SetValue(TValue value)
    {
        //TODO dit moet beter kunnen
        //var prop = Value.GetPropertyInfo();
        //prop.SetValue(Value.GetContext(), value);
    }
}
