using UnityEngine;

namespace Data
{
    public class PlayerPrefsManager : IDataManager
    {
        public object Load(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public void Save(string key, object value)
        {
            PlayerPrefs.SetString(key, value.ToString());
        }
    }
}