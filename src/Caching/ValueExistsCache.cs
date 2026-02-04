using System.Collections.Concurrent;

namespace Enum2String;

internal static class ValueExistsCache
{
    // Actually - without Default value
    // Full - with Default value
    public static ConcurrentDictionary<(Type, string), (bool Actually, bool Full)> Cache { get; private set; } = [];

    public static void Add(Type type, string name, (bool Actually, bool Full) data)
    {
        Cache.TryAdd((type, name), data);
    }

    public static bool TryAdd(Type type, string name, (bool Actually, bool Full) data)
    {
        return Cache.TryAdd((type, name), data);
    }

    public static (bool Actually, bool Full) Get(Type type, string name)
    {
        Cache.TryGetValue((type, name), out (bool, bool) data);
        return data;
    }

    public static bool TryGet(Type type, string name, out (bool Actually, bool Full) data)
    {
        bool result = Cache.TryGetValue((type, name), out (bool, bool) val);
        data = val;
        return result;
    }

    public static bool Has(Type type, string name)
    {
        return Cache.ContainsKey((type, name));
    }
}