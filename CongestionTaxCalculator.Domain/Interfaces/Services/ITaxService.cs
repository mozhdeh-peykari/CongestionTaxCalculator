namespace CongestionTaxCalculator.Domain.Interfaces.Services
{
    public interface ITaxService
    {
        Task<int> CalculateCongestionTax(List<DateTime> passes);
    }
}
