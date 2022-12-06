using UnityEngine;

namespace Data
{
    public class DataManager : IDataManager
    {
        private string _key;

        public DataManager(string key)
        {
            _key = key;
        }

        public string Load()
        {
            return PlayerPrefs.GetString(_key);
        }

        public void Save(string value)
        {
            PlayerPrefs.SetString(_key, value);
        }
    }
}