using System.Collections.Generic;

namespace Polgresso.Entities.Vehicles
{
    public class Make
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }

        public ICollection<VehicleMake> VehicleMakes { get; set; }
    }
}