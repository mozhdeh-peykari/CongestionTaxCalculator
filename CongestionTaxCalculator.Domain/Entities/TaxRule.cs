using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public class TaxRule : BaseEntity
    {
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public int Amount { get; set; }
    }
}
