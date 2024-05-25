using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Infrastructure.Repositories
{
    public class TaxExemptionRepository : Repository<TaxExemption>, ITaxExemptionRepository
    {
        public TaxExemptionRepository(CongestionTaxContext context) : base(context)
        {
        }
    }
}
