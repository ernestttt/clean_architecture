public interface IDataManager
{
    public object Load(string key);
    public void Save(string key,object value);
}