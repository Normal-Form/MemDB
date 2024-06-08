using System.Collections.Concurrent;
using MemDB.Interfaces;

namespace MemDB.Models;

public class DictionaryDB : IRecordDB
{
    protected ConcurrentDictionary<string, string> DB { get; set; } = new ConcurrentDictionary<string, string>();

    public string Get(string key)
    {
        if (this.DB.TryGetValue(key, out string? result))
        {
            return result;        
        }

        return "";
    }

    public bool Set(string key, string value)
    {
        return this.DB.TryAdd(key, value);
    }
}
