using System.Diagnostics;

namespace Monad;

public static class Value
{
    [DebuggerStepThrough]
    public static T? Exchange<T>(ref T target, T source)
        => Exchange(ref target, source, (_, _) => { });

    [DebuggerStepThrough]
    public static T? Exchange<T>(ref T target, T source, Action changed)
        => Exchange(ref target, source, (_, _) => changed());

    [DebuggerStepThrough]
    public static T? Exchange<T>(ref T target, T source, Action<T> changed)
        => Exchange(ref target, source, (_, v) => changed(v));

    [DebuggerStepThrough]
    public static T? Exchange<T>(ref T target, T source, Action<T, T> changed)
    {
        if (!Equals(source, target))
        {
            var prevTarget = target;
            target = source;

            changed(prevTarget, target);
            return prevTarget;
        }

        return default;
    }
}
