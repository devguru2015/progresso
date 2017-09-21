using Polgresso.Entities.Coverages;
using System.Collections.Generic;

namespace Polgresso.Entities
{
    /// <summary>
    /// Represents a state.
    /// </summary>
    public class State
    {
        public State()
        {
            Applications = new List<Application>();
            StateCoverages = new List<StateCoverage>();
        }

        /// <summary>
        /// The state's abbreviation.
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// The state's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Applications associated with a state.
        /// </summary>
        public ICollection<Application> Applications { get; set; }

        /// <summary>
        /// Coverages offered for a state.
        /// </summary>
        public ICollection<StateCoverage> StateCoverages { get; set; }
    }
}