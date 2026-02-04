using System.Collections.Concurrent;

namespace Enum2String;

internal static class FieldValueCache
{
    public static ConcurrentDictionary<(Type, string), string> Cache { get; private set; } = [];

    public static void Add(Type type, string name, string value)
    {
        Cache.TryAdd((type, name), value);
    }

    public static bool TryAdd(Type type, string name, string value)
    {
        return Cache.TryAdd((type, name), value);
    }

    public static string Get(Type type, string name)
    {
        Cache.TryGetValue((type, name), out string? val);
        return val is null ? name : val;
    }

    public static bool TryGet(Type type, string name, out string value)
    {
        string? val;
        bool result = Cache.TryGetValue((type, name), out val);
        value = val is null ? name : val;
        return result;
    }

    public static bool Has(Type type, string name)
    {
        return Cache.ContainsKey((type, name));
    }
}