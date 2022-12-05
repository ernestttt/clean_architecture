namespace UseCase
{
    public interface ISaveLoadUseCase
    {
        public string Load();
        public void Save(string value);
    }
}