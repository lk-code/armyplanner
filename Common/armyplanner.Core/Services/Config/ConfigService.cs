using armyplanner.Core.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;

namespace armyplanner.Core.Services.Config
{
    public class ConfigService : IConfigService
    {
        #region Konstanten

        #endregion

        #region Events

        #endregion

        #region Private Elemente

        /// <summary>
        /// 
        /// </summary>
        private JObject _secrets = null;

        #endregion

        #region Properties

        #endregion

        #region Konstruktoren

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
            this._secrets = null;
        }

        #endregion

        #region Worker

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appNamespace"></param>
        /// <param name="settingsFile"></param>
        /// <param name="assembly"></param>
        public void Initialize(string appNamespace, string settingsFile, Assembly assembly)
        {
            string resourceFileName = $"{appNamespace}.{settingsFile}";
            Stream stream = assembly.GetManifestResourceStream(resourceFileName);

            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();

                _secrets = JObject.Parse(json);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Get(string name)
        {
            string[] path = name.Split(':');

            JToken node = _secrets[path[0]];
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