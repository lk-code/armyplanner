using Newtonsoft.Json.Linq;

namespace armyplanner.Core.Interfaces
{
    public interface IConfigService
    {
        void Initialize(JObject configObject);
        string Get(string name);
        T Get<T>(string name);
    }
}