using armyplanner.Core.Interfaces;
using Newtonsoft.Json.Linq;
using System;

namespace armyplanner.Core.Services.Config
{
    public class ConfigService : IConfigService
    {
        #region # properties #

        /// <summary>
        /// 
        /// </summary>
        private JObject _configObject = null;

        #endregion

        #region # constructors #

        /// <summary>
        /// 
        /// </summary>
        public ConfigService()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ~ConfigService()
        {
            this._configObject = null;
        }

        #endregion

        #region # public methods #

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configObject"></param>
        public void Initialize(JObject configObject)
        {
            this._configObject = configObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Get(string name)
        {
            string[] path = name.Split(':');

            JToken node = _configObject[path[0]];
            for (int index = 1; index < path.Length; index++)
            {
                node = node[path[index]];
            }

            return node.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Get<T>(string name)
        {
            string value = this.Get(name);
            T result = (T)Convert.ChangeType(value, typeof(T));

            return result;
        }

        #endregion
    }
}