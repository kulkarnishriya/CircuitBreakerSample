namespace CircuitBreakerSample.Interface
{
    public interface IStockService
    {
        public Task<string> GetStock();
    }
}
