using System;
using System.Collections.Generic;

namespace Polgresso.PolicyMaker.Entities
{
    public class Policy
    {
        public Guid Id { get; set; }

        public NamedInsured NamedInsured { get; set; }

        public ICollection<Driver> Drivers { get; set; }
    }
}