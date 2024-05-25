using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Interfaces.Repositories;
using CongestionTaxCalculator.Domain.Interfaces.Services;

namespace CongestionTaxCalculator.Domain.Services
{
    public class TaxService : ITaxService
    {
        private const int MaxDailyTax = 60; //TODO: set in appsettings

        private readonly ITaxRuleRepository _taxRuleRepository;
        private readonly ITaxExemptionRepository _taxExemptionRepository;

        public TaxService(ITaxRuleRepository taxRuleRepository,
            ITaxExemptionRepository taxExemptionRepository)
        {
            _taxRuleRepository = taxRuleRepository;
            _taxExemptionRepository = taxExemptionRepository;
        }

        public async Task<int> CalculateCongestionTax(List<DateTime> passes)
        {
            await ExcludeExemptPasses(passes);
            return await GetMaxCongestionTax(passes);
        }

        private async Task<int> GetMaxCongestionTax(List<DateTime> passes)
        {
            var taxRules = await _taxRuleRepository.GetAllAsync();
            int totalTax = 0;
            DateTime intervalStart = passes[0];
            int intervalMaxTax = GetTaxAmount(taxRules, intervalStart);

            for (int i = 1; i < passes.Count; i++)
            {
                DateTime currentTime = passes[i];
                if ((currentTime - intervalStart).TotalMinutes <= 60)
                {
                    intervalMaxTax = Math.Max(intervalMaxTax, GetTaxAmount(taxRules, currentTime));
                }
                else
                {
                    totalTax += intervalMaxTax;
                    intervalMaxTax = GetTaxAmount(taxRules, currentTime);
                    intervalStart = currentTime;
                }
            }

            totalTax += intervalMaxTax;
            return Math.Min(totalTax, MaxDailyTax);
        }

        private async Task ExcludeExemptPasses(List<DateTime> passes)
        {
            var exemptions = await _taxExemptionRepository.GetAllAsync();
            foreach (var pass in passes)
            {
                var isPassTaxExempt = exemptions.Any(e => (e.Type == TaxExemptionType.DayOfYear && e.Value == pass.DayOfYear) ||
                                                             (e.Type == TaxExemptionType.Month && e.Value == pass.Month) ||
                                                             (e.Type == TaxExemptionType.DayOfWeek && e.Value == (int)pass.DayOfWeek));

                if (isPassTaxExempt)
                    passes.Remove(pass);
            }
        }

        private int GetTaxAmount(IEnumerable<TaxRule> taxRules, DateTime pass)
        {
            foreach (var rule in taxRules)
            {
                if (pass.TimeOfDay >= rule.From && pass.TimeOfDay <= rule.To)
                {
                    return rule.Amount;
                }
            }

            return 0;
        }
    }
}
