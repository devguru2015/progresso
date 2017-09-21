namespace Polgresso.Entities.Drivers
{
    /// <summary>
    /// Represents the motor vehicle violations of the driver.
    /// </summary>
    public class DriverViolation
    {
        /// <summary>
        /// The unique identifier of the driver.
        /// </summary>
        public int DriverId { get; set; }
       
        /// <summary>
        /// The driver.
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// The unique identifier of the violation.
        /// </summary>
        public int ViolationId { get; set; }

        /// <summary>
        /// The motor vehicle violation.
        /// </summary>
        public Violation Violation { get; set; }
    }
}