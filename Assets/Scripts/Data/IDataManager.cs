namespace Data
{
    public interface IDataManager
    {
        public string Load();
        public void Save(string value);
    }
}