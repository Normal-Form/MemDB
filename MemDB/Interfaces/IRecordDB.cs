namespace MemDB.Interfaces;

public interface IRecordDB
{
    bool Set(string key, string value);
    string Get(string key);
}
