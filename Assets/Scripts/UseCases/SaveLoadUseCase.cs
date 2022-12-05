using Entities;

namespace UseCase
{
    public class SaveLoadUseCase : ISaveLoadUseCase
    {
        private string _key;

        private ISaveLoadEntity _saveLoadEntity;

        public SaveLoadUseCase(string key, ISaveLoadEntity saveLoadEntity)
        {
            _key = key;
            _saveLoadEntity = saveLoadEntity;
        }

        public string Load()
        {
            return _saveLoadEntity.Load(_key);
        }

        public void Save(string value)
        {
            _saveLoadEntity.Save(_key, value);
        }
    }
}