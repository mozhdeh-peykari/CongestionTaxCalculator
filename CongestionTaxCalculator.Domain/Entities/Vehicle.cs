namespace CongestionTaxCalculator.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Model { get; set; }

        public string Registration { get; set; }

        public int VehicleTypeId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}
