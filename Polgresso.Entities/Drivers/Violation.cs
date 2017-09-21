using System.Collections.Generic;

namespace Polgresso.Entities.Drivers
{
    /// <summary>
    /// Represents a driving violation.
    /// </summary>
    public class Violation
    {
        /// <summary>
        /// The unique identifier of the violation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ACD code of the violation.
        /// </summary>
        public string AcdCode { get; set; }

        /// <summary>
        /// The description of the violation.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The violations of the driver.
        /// </summary>
        public ICollection<DriverViolation> DriverViolations { get; set; }
    }
}