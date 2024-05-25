using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CongestionTaxContext context) : base(context)
        {
        }

        public async override Task<Vehicle> GetByIdAsync(int id)
        {
            return await _dbSet.Include(e=>e.VehicleType).FirstOrDefaultAsync(e=>e.Id == id);
        }
    }
}
