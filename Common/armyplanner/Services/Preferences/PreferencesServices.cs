using armyplanner.Core.Interfaces;
using System;
using System.Globalization;

namespace armyplanner.Services.Preferences
{
    public class PreferencesServices : IPreferencesServices
    {
        static readonly object locker = new object();

        /// <summary>
        /// 
        /// </summary>
        public PreferencesServices()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sharedName"></param>
        public void Clear(string sharedName)
        {
            Xamarin.Essentials.Preferences.Clear(sharedName);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            Xamarin.Essentials.Preferences.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sharedName"></param>
        /// <returns></returns>
        public bool ContainsKey(string key, string sharedName)
        {
            return Xamarin.Essentials.Preferences.ContainsKey(key, sharedName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return Xamarin.Essentials.Preferences.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sharedName"></param>
        public void Remove(string key, string sharedName)
        {
            Xamarin.Essentials.Preferences.Remove(key, sharedName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            Xamarin.Essentials.Preferences.Remove(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T Get<T>(string key, T defaultValue)
        {
            object value = null;

            lock (locker)
            {
                switch (defaultValue)
                {
                    case int i:
                        value = Xamarin.Essentials.Preferences.Get(key, i);
                        break;
                    case bool b:
                        value = Xamarin.Essentials.Preferences.Get(key, b);
                        break;
                    case long l:
                        long savedLong = Xamarin.Essentials.Preferences.Get(key, Convert.ToInt64(l, CultureInfo.InvariantCulture));
                        value = Convert.ToInt64(savedLong, CultureInfo.InvariantCulture);
                        break;
                    case double d:
                        value = Xamarin.Essentials.Preferences.Get(key, d);
                        break;
                    case float f:
                        value = Xamarin.Essentials.Preferences.Get(key, f);
                        break;
                    case string s:
                        value = Xamarin.Essentials.Preferences.Get(key, s);
                        break;
                }
            }

            return (T)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="sharedName"></param>
        /// <returns></returns>
        public T Get<T>(string key, T defaultValue, string sharedName)
        {
            object value = null;

            lock (locker)
            {
                switch (defaultValue)
                {
                    case int i:
                        value = Xamarin.Essentials.Preferences.Get(key, i, sharedName);
                        break;
                    case bool b:
                        value = Xamarin.Essentials.Preferences.Get(key, b, sharedName);
                        break;
                    case long l:
                        long savedLong = Xamarin.Essentials.Preferences.Get(key, Convert.ToInt64(l, CultureInfo.InvariantCulture), sharedName);
                        value = Convert.ToInt64(savedLong, CultureInfo.InvariantCulture);
                        break;
                    case double d:
                        value = Xamarin.Essentials.Preferences.Get(key, d, sharedName);
                        break;
                    case float f:
                        value = Xamarin.Essentials.Preferences.Get(key, f, sharedName);
                        break;
                    case string s:
                        value = Xamarin.Essentials.Preferences.Get(key, s, sharedName);
                        break;
                }
            }

            return (T)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set<T>(string key, T value)
        {
            lock (locker)
            {
                switch (value)
                {
                    case int i:
                        Xamarin.Essentials.Preferences.Set(key, i);
                        break;
                    case bool b:
                        Xamarin.Essentials.Preferences.Set(key, b);
                        break;
                    case long l:
                        Xamarin.Essentials.Preferences.Set(key, Convert.ToInt64(l, CultureInfo.InvariantCulture));
                        break;
                    case double d:
                        Xamarin.Essentials.Preferences.Set(key, d);
                        break;
                    case float f:
                        Xamarin.Essentials.Preferences.Set(key, f);
                        break;
                    case string s:
                        Xamarin.Essentials.Preferences.Set(key, s);
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="sharedName"></param>
        public void Set<T>(string key, T value, string sharedName)
        {
            lock (locker)
            {
                switch (value)
                {
                    case int i:
                        Xamarin.Essentials.Preferences.Set(key, i, sharedName);
                        break;
                    case bool b:
                        Xamarin.Essentials.Preferences.Set(key, b, sharedName);
                        break;
                    case long l:
                        Xamarin.Essentials.Preferences.Set(key, Convert.ToInt64(l, CultureInfo.InvariantCulture), sharedName);
                        break;
                    case double d:
                        Xamarin.Essentials.Preferences.Set(key, d, sharedName);
                        break;
                    case float f:
                        Xamarin.Essentials.Preferences.Set(key, f, sharedName);
                        break;
                    case string s:
                        Xamarin.Essentials.Preferences.Set(key, s, sharedName);
                        break;
                }
            }
        }
    }
}