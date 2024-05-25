using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public class VehicleType: BaseEntity
    {
        public string Name { get; set; }
        public bool IsTaxExempt { get; set; }
    }
}
