namespace Presentation.Utils.ApiClient
{
    public interface IApiClient
    {
        Task<Guid> CreateEntityAsync(string url, JsonContent content);
        Task<T> PostAsync<T>(string url, JsonContent content) where T : class;
        Task<bool> DeleteAsync(string url, Guid guid);
        Task<bool> PutAsync(string url, JsonContent content);
        Task<T> GetAsync<T>(string url, Guid? id = null);
    }
}
