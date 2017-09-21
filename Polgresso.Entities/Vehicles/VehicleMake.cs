namespace Polgresso.Entities.Vehicles
{
    public class VehicleMake
    {
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int MakeId { get; set; }

        public Make Make { get; set; }
    }
}