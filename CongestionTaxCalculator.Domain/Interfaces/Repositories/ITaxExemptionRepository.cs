using CongestionTaxCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Interfaces.Repositories
{
    public interface ITaxExemptionRepository : IRepository<TaxExemption>
    {
    }
}
