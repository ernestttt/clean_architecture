using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public interface ISaveLoadEntity
    {
        public void Save(string key, string value);
        public string Load(string key);
    }
}
