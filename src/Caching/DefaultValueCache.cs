using System.Collections.Concurrent;

namespace Enum2String;

internal static class DefaultValueCache
{
    public static ConcurrentDictionary<Type, string> Cache { get; private set; } = [];

    public static void Add(Type type, string value)
    {
        Cache.TryAdd(type, value);
    }

    public static bool TryAdd(Type type, string value)
    {
        return Cache.TryAdd(type, value);
    }

    public static string Get(Type type)
    {
        Cache.TryGetValue(type, out string? val);
        return val is null ? "" : val;
    }

    public static bool TryGet(Type type, out string value)
    {
        bool result = Cache.TryGetValue(type, out string? val);
        value = val is null ? "" : val;
        return result;
    }

    public static bool Has(Type type)
    {
        return Cache.ContainsKey(type);
    }
}