using System.Reflection;

namespace armyplanner.Core.Interfaces
{
    public interface IConfigService
    {
        void Initialize(string appNamespace, string settingsFile, Assembly assembly);
        string Get(string name);
        T Get<T>(string name);
    }
}