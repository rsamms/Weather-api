using System.Net.Http.Headers;
using System.Reflection;

namespace Weather.Api.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpRequestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync<T>(string clientName, string requestUri, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient(clientName);

            ProductHeaderValue header = new ProductHeaderValue("pocweatherservice", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);


            var response = await client.GetFromJsonAsync<T>(requestUri, cancellationToken);

            return response;
        }
    }
}
