using CongestionTaxCalculator.Domain.Interfaces.Repositories;
using CongestionTaxCalculator.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITaxService _taxService;
        public TaxController(IVehicleRepository vehicleRepository,
            ITaxService taxService)
        {
            _vehicleRepository = vehicleRepository;
            _taxService = taxService;
        }

        [HttpGet]
        public async Task<int> Get(int vehicleId, [FromQuery] List<DateTime> passes)
        {
            if (vehicleId == 0)
                throw new ArgumentException("VehicleId cannot be 0");

            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);
            if (vehicle == null)
                throw new ArgumentException("Invalid VehicleId");

            if (vehicle.VehicleType.IsTaxExempt)
                return 0;

            return await _taxService.CalculateCongestionTax(passes);
        }
    }
}
