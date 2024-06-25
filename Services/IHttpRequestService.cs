namespace Weather.Api.Services
{
    public interface IHttpRequestService
    {
        Task<T> GetAsync<T>(string clientName, string requestUri, CancellationToken cancellationToken);
    }
}
