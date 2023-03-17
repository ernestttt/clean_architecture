public class DataCommunicator : IDataCommunicator
{
    private string _key;
    private IDataManager _dataManager;

    public DataCommunicator(string key, IDataManager dataManager)
    {
        _key = key;
        _dataManager = dataManager;
    }
    
    public string Load()
    {
        return (_dataManager.Load(_key) as string) ?? string.Empty;
    }

    public void Save(string line)
    {
        _dataManager.Save(_key, line);
    }
}
