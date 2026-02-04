using System.Collections.Concurrent;

namespace Enum2String;

internal static class ValueExistsCache
{
    // Actually - without Default value
    // Full - with Default value
    public static ConcurrentDictionary<(Type, string), bool> Cache { get; private set; } = [];

    public static void Add(Type type, string name, bool exists)
    {
        Cache.TryAdd((type, name), exists);
    }

    public static bool TryAdd(Type type, string name, bool exists)
    {
        return Cache.TryAdd((type, name), exists);
    }

    public static bool Get(Type type, string name)
    {
        Cache.TryGetValue((type, name), out bool data);
        return data;
    }

    public static bool TryGet(Type type, string name, out bool exists)
    {
        bool result = Cache.TryGetValue((type, name), out bool val);
        exists = val;
        return result;
    }

    public static bool Has(Type type, string name)
    {
        return Cache.ContainsKey((type, name));
    }
}