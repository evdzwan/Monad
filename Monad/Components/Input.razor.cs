using Microsoft.AspNetCore.Components;
using System.Drawing;
using System.Globalization;

namespace Monad.Components;

public partial class Input<TValue>
{
    private InputType EffectiveType => Type switch
    {
        InputType.Auto => Value switch
        {
            Color => InputType.Color,
            DateTime or DateTimeOffset => InputType.DateTime,
            decimal or double or float or int or long => InputType.Number,
            TimeSpan => InputType.Time,
            _ => InputType.Text
        },
        _ => Type
    };

    private string EffectiveTypeString => EffectiveType switch
    {
        InputType.DateTime => "datetime-local",
        InputType.Telephone => "tel",
        _ => EffectiveType.ToString().ToLowerInvariant()
    };

    private string? EffectiveValue
    {
        get => Value switch
        {
            Color color => EffectiveType switch
            {
                InputType.Color => $"#{color.R:X2}{color.G:X2}{color.B:X2}",
                _ => Value?.ToString()
            },
            DateTime dateTime => EffectiveType switch
            {
                InputType.Date => BindConverter.FormatValue(dateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                InputType.DateTime => BindConverter.FormatValue(dateTime, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                InputType.Month => BindConverter.FormatValue(dateTime, "yyyy-MM", CultureInfo.InvariantCulture),
                InputType.Time => BindConverter.FormatValue(dateTime, "HH:mm:ss", CultureInfo.InvariantCulture),
                InputType.Week => $"{dateTime:yyyy}-W{ISOWeek.GetWeekOfYear(dateTime)}",
                _ => Value?.ToString()
            },
            DateTimeOffset dateTimeOffset => EffectiveType switch
            {
                InputType.Date => BindConverter.FormatValue(dateTimeOffset.DateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                InputType.DateTime => BindConverter.FormatValue(dateTimeOffset.DateTime, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                InputType.Month => BindConverter.FormatValue(dateTimeOffset.DateTime, "yyyy-MM", CultureInfo.InvariantCulture),
                InputType.Time => BindConverter.FormatValue(dateTimeOffset.DateTime, "HH:mm:ss", CultureInfo.InvariantCulture),
                InputType.Week => $"{dateTimeOffset.DateTime:yyyy}-W{ISOWeek.GetWeekOfYear(dateTimeOffset.DateTime)}",
                _ => Value?.ToString()
            },
            _ => Value?.ToString()
        };
        set
        {
            Value = EffectiveType switch
            {
                InputType.Color => ColorTranslator.FromHtml(value!) is TValue typedValue ? typedValue : default!,
                InputType.Week => ISOWeek.ToDateTime(int.Parse(value?.Split("-W")[0] ?? "0"), int.Parse(value?.Split("-W")[1] ?? "1"), DayOfWeek.Monday) is TValue typedValue ? typedValue : default!,
                _ => BindConverter.TryConvertTo<TValue>(value, CultureInfo.InvariantCulture, out var typedValue) ? typedValue : default!
            };
        }
    }

    [Parameter]
    public TValue? Maximum { get; set; }

    [Parameter]
    public TValue? Minimum { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public TValue? Step { get; set; }

    [Parameter]
    public InputType Type { get; set; } = InputType.Auto;

    [Parameter, EditorRequired]
    public required TValue Value { get; set; }

    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    private Dictionary<string, object?> GetAttributes()
    {
        var attributes = new Dictionary<string, object?>();
        if (Minimum is not null)
        {
            attributes.Add("min", Minimum);
        }
        if (Maximum is not null)
        {
            attributes.Add("max", Maximum);
        }
        if (Step is not null)
        {
            attributes.Add("step", Step);
        }

        return attributes;
    }

    private Task InvokeValueChanged()
        => ValueChanged.InvokeAsync(Value);
}
