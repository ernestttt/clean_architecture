using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class SaveLoadEntity : ISaveLoadEntity
    {
        public string Load(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public void Save(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
    }
}