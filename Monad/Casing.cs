using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Monad;

public static partial class Casing
{
    [DebuggerStepThrough]
    public static string ToKebabCase(string str)
        => ToKebabCaseRegex().Replace(str, "-$1").ToLowerInvariant();

    [GeneratedRegex(@"(?<!^)(?<!-)((?<=\p{Ll})\p{Lu}|\p{Lu}(?=\p{Ll}))")]
    private static partial Regex ToKebabCaseRegex();
}
