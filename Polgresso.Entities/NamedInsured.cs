using System.ComponentModel.DataAnnotations;

namespace Polgresso.Entities
{
    /// <summary>
    /// The person who will become the policy holder.
    /// </summary>
    public class NamedInsured
    {
        public NamedInsured()
        {
            PhysicalAddress = new Address();
            MailingAddress = new Address();
        }
        /// <summary>
        /// The name insured's unique identifier.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The first name of the insured.
        /// </summary>
        [Required]
        public string Firstname { get; set; }

        /// <summary>
        /// The last name of the insured.
        /// </summary>
        [Required]
        public string Lastname { get; set; }

        /// <summary>
        /// The physical address of the insured.
        /// </summary>
        public Address PhysicalAddress { get; set; }

        /// <summary>
        /// The mailing address of the insured.
        /// </summary>
        public Address MailingAddress { get; set; }

        /// <summary>
        /// The primary phone number of the insured.
        /// </summary>
        [Required]
        public string PrimaryPhoneNumber { get; set; }

        /// <summary>
        /// The secondary phone number of the insured.
        /// </summary>
        public string SecondaryPhoneNumber { get; set; }

        /// <summary>
        /// The named insured's online application.
        /// </summary>
        public Application Application { get; set; }

        /// <summary>
        /// The named insured's application id.
        /// </summary>
        [Required]
        public int ApplicationId { get; set; }
    }
}