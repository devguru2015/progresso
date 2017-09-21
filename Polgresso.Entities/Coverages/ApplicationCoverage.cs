namespace Polgresso.Entities.Coverages
{
    /// <summary>
    /// Represents the coverages on the application.
    /// </summary>
    public class ApplicationCoverage
    {
        /// <summary>
        /// The unique identifier for the application.
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// The unique identifier for the coverage.
        /// </summary>
        public int CoverageId { get; set; }

        #region Navigation Properties 

        /// <summary>
        /// The application associated with the coverage.
        /// </summary>
        public Application Application { get; set; }

        /// <summary>
        /// The coverage associated with the application.
        /// </summary>
        public Coverage Coverage { get; set; }

        #endregion
    }
}