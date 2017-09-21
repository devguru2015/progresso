namespace Polgresso.Entities.Vehicles
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }
    }
}