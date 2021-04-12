namespace armyplanner.Core.Interfaces
{
    public interface IPreferencesServices
    {
        void Clear(string sharedName);
        void Clear();
        bool ContainsKey(string key, string sharedName);
        bool ContainsKey(string key);
        void Remove(string key, string sharedName);
        void Remove(string key);
        void Set<T>(string key, T value);
        void Set<T>(string key, T value, string sharedName);
        T Get<T>(string key, T defaultValue);
        T Get<T>(string key, T defaultValue, string sharedName);
    }
}