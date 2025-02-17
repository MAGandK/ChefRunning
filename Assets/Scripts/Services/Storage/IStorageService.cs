namespace Services.Storage
{
    public interface IStorageService
    {
        T GetData<T>(string key) where T : class, IStorageData;
    }
}
