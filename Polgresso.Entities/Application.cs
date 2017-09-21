using Polgresso.Entities.Coverages;
using Polgresso.Entities.Drivers;
using Polgresso.Entities.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polgresso.Entities
{
    /// <summary>
    /// Represents an online application with Polgresso.
    /// </summary>
    public class Application
    {
        public Application()
        {
            Drivers = new List<Driver>();
            Vehicles = new List<Vehicle>();
            ApplicationCoverages = new List<ApplicationCoverage>();
        }

        /// <summary>
        /// The unique identifier of the application.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The state applicable to the policy.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// The state's id.
        /// </summary> 
        [Required]
        public string StateAbbreviation { get; set; }

        /// <summary>
        /// The person who will become the policy holder.
        /// </summary>
        public NamedInsured NamedInsured { get; set; }

        /// <summary>
        /// The drivers on the application.
        /// </summary>
        public ICollection<Driver> Drivers { get; set; }

        /// <summary>
        /// The vehicles on the application.
        /// </summary>
        public ICollection<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// The coverages on the application.
        /// </summary>
        public ICollection<ApplicationCoverage> ApplicationCoverages { get; set; }
    }
}