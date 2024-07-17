using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Monad.Components.Controls;

public class DataGridExpressionColumn<TItem, TValue> : DataGridColumn<TItem>
{
    private Func<TItem, TValue> CompiledValue { get; set; } = default!;

    [Parameter, EditorRequired, Description("Value expression.")]
    public required Expression<Func<TItem, TValue>> Value { get; set; }

    protected override RenderFragment<TItem> CreateCellContent()
        => item => builder => builder.AddContent(sequence: 0, CompiledValue(item));

    protected override RenderFragment CreateHeaderContent()
        => builder => builder.AddContent(sequence: 0, Title ?? (Value.Body is MemberExpression me ? me.Member.Name : null));

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        var prevValue = Value;
        await base.SetParametersAsync(parameters);
        if (Value != prevValue)
        {
            CompiledValue = Value.Compile();
        }
    }
}
