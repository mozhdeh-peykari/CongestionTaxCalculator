using CongestionTaxCalculator.API.Models;
using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Interfaces.Repositories;
using CongestionTaxCalculator.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        public async Task<int> Get(GetTaxRequest request)
        {
            if (request.VehicleId == 0)
                throw new ArgumentException("VehicleId cannot be 0");

            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
            if (vehicle == null)
                throw new ArgumentException("Invalid VehicleId");

            if (vehicle.VehicleType.IsTaxExempt)
                return 0;

            return await _taxService.CalculateCongestionTax(request.Passes);
        }
    }
}
