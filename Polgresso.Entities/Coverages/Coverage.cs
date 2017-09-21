using System.Collections.Generic;

namespace Polgresso.Entities.Coverages
{
    /// <summary>
    /// Represents an insurance coverage.
    /// </summary>
    public class Coverage
    {
        /// <summary>
        /// The unique identifier of the coverage.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the coverage.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The coverage code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The description of the coverage.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The coverages offered in a state.
        /// </summary>
        public ICollection<StateCoverage> StateCoverages { get; set; }

        /// <summary>
        /// The coverages on the application.
        /// </summary>
        public ICollection<ApplicationCoverage> ApplicationCoverages { get; set; }
    }
}