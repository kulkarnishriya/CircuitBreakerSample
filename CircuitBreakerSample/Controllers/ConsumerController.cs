using CircuitBreakerSample.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CircuitBreakerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerController : ControllerBase
    {
        
        private readonly ILogger<ConsumerController> _logger;
        private readonly IStockService _stockService;

        public ConsumerController(ILogger<ConsumerController> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        // GET: Stock
        [HttpGet(Name = "GetStock")]
        public Task<string> GetStockDetails()
        {
            try
            {
               return _stockService.GetStock();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
