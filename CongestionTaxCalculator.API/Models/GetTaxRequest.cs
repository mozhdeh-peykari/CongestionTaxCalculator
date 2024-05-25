using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculator.API.Models
{
    public class GetTaxRequest
    {
        [Required]
        public int VehicleId { get; set; }
        public List<DateTime> Passes { get; set; }
    }
}
