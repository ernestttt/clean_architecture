namespace Domain
{
    public class LoadSaveUseCase
    {
        private IDataCommunicator _communicator;
        private IUpdatedLine _updatedLine;

        public LoadSaveUseCase(IDataCommunicator communicator)
        {
            _communicator = communicator;
        }

        public void SetUpdatedLine(IUpdatedLine updatedLine)
        {
            _updatedLine = updatedLine;
        }

        public void StartOfApp()
        {
            _updatedLine.UpdatedLine = _communicator.Load();
        }

        public void UpdateLine(string line)
        {
            _communicator.Save(line);
        }
    }
}