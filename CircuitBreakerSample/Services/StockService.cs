using CircuitBreakerSample.Interface;
using Polly.CircuitBreaker;

namespace CircuitBreakerSample.Services
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //Gets stock data from external service using HTTP call
        public async Task<string> GetStock()
        {
            try
            {
                var httpRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost:5178/Publisher")
                };
                var response = await _httpClient.SendAsync(httpRequest);
                response.EnsureSuccessStatusCode();
                var responsebody = await response.Content.ReadAsStringAsync();
                return responsebody;
            }
            catch (BrokenCircuitException ex)
            {

                return $"Request failed due to opened circuit: {ex.Message}";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
