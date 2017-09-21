namespace Polgresso.Entities.Coverages
{
    /// <summary>
    /// Represents the coverages available for a state.
    /// </summary>
    public class StateCoverage
    {
        /// <summary>
        /// The unique identifier of the state coverage relationship.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The abbreviation of the state.
        /// </summary>
        public string StateAbbreviation { get; set; }  

        /// <summary>
        /// The unique identifier of the coverage.
        /// </summary>
        public int CoverageId { get; set; }

        /// <summary>
        /// <para>
        /// If the coverage is Bodily Injury, this represents the maximum amount Polgresso 
        /// will pay when one person is injured by the insured.
        /// </para>
        /// <para>
        /// If coverage is Uninsured Motorist Bodily Injury, this represents the maximum 
        /// amount Polgresso will pay when the insured is injured by an uninsured driver.
        /// </para>
        /// </summary>
        public decimal? PerPersonLimit { get; set; }

        /// <summary> 
        /// <para>
        /// If the coverage is Bodily Injury, this represents the maximum amount Polgresso 
        /// will pay when multiple people are injured by the insured.
        /// </para>
        /// <para>
        /// If coverage is Property Damage, this represents the maximum amount Polgresso 
        /// will pay when property is damaged by the insured.
        /// </para>
        /// <para>
        /// If coverage is Uninsured Motorist Bodily Injury, this represents the maximum 
        /// amount Polgresso will pay when multiple people are injured by an uninsured driver.
        /// </para>
        /// <para>
        /// If coverage is Uninsured Motorist Property Damage, this represents the maximum 
        /// amount Polgresso will pay when the insured's vehicle is damaged by an uninsured driver.
        /// </para>
        /// </summary>
        public decimal? PerAccidentLimit { get; set; }

        /// <summary>
        /// <para>
        /// If the insured has Collision coverage, this represents the amount the insured must pay
        /// out-of-pocket before Polgresso pays to repair damages on the insured's vehicle caused by
        /// a collision.
        /// </para>
        /// <para>
        /// If the insured has Comprehensive coverage, this represents the amount the insured must pay
        /// out-of-pocket before Polgresso pays to repair damages on the insured's vehicle not caused by
        /// a collision.  For example, theft, vandalism, weather, etc.
        /// </para>
        /// </summary>
        public decimal? Deductible { get; set; }

        /// <summary>
        /// Indicates if the coverage is required for this state.
        /// </summary>
        public bool IsRequired { get; set; }

        #region Navigation Properties

        /// <summary>
        /// The state associated with the coverage.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// The coverage associated with the state.
        /// </summary>
        public Coverage Coverage { get; set; }

        #endregion
    }
}