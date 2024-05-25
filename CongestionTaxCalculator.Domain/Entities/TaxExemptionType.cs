using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public enum TaxExemptionType : byte
    {
        DayOfYear = 1,
        Month = 2,
        DayOfWeek = 3,
    }
}
