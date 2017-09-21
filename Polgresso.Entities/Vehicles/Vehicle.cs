using System.Collections.Generic;

namespace Polgresso.Entities.Vehicles
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Vin { get; set; }

        public int Year { get; set; }

        public VehicleType Type { get; set; }

        public string OriginCountry { get; set; }

        public string Color { get; set; }

        public string Class { get; set; }

        public int Cylinders { get; set; }

        public string Transmission { get; set; }

        public bool HasAbsBrakes { get; set; }

        public bool HasAntiTheft { get; set; }

        public ICollection<VehicleMake> VehicleMakes { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }

    }
}