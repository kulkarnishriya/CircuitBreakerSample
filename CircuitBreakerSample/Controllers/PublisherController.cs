using Microsoft.AspNetCore.Mvc;

namespace CircuitBreakerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private static readonly string[] StockItems = new[]
        {
        "Macbook","HP laptop","iphone13", "USB cable", "Smart watch"
    };

        private readonly ILogger<PublisherController> _logger;

        public PublisherController(ILogger<PublisherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStockData")]
        public IEnumerable<string> Get()
        {
            return StockItems.ToArray();
        }
    }
}