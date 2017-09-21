using System;

namespace Polgresso.PolicyMaker.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }

        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Vin { get; set; }
    }
}