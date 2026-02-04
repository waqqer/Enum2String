using System.Collections.Concurrent;

namespace Enum2String;

internal static class DefaultValueCache
{
    public static ConcurrentDictionary<Type, (string value, bool has)> Cache { get; private set; } = [];

    public static void Add(Type type, string value, bool has)
    {
        Cache.TryAdd(type, (value, has));
    }

    public static bool TryAdd(Type type, string value, bool has)
    {
        return Cache.TryAdd(type, (value, has));
    }

    public static (string value, bool has) Get(Type type)
    {
        Cache.TryGetValue(type, out (string, bool) val);
        return val;
    }

    public static bool TryGet(Type type, out (string value, bool has) value)
    {
        bool result = Cache.TryGetValue(type, out (string, bool) val);
        value = val;
        return result;
    }

    public static bool Has(Type type)
    {
        return Cache.ContainsKey(type);
    }
}