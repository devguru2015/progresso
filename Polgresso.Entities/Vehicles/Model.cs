using System.Collections.Generic;

namespace Polgresso.Entities.Vehicles
{
    public class Model
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public int MakeId { get; set; }

        public Make Make { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}