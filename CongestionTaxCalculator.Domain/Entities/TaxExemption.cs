using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public class TaxExemption : BaseEntity
    {
        public TaxExemptionType Type { get; set; }
        public int Value { get; set; }
    }
}
