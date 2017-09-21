using Polgresso.Entities;
using System.ComponentModel.DataAnnotations;

namespace Polgresso.Dtos
{
    public class NamedInsuredDto
    {
        [ScaffoldColumn(false)]
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
        [Required]
        public Address PhysicalAddress { get; set; }

        /// <summary>
        /// The mailing address of the insured.
        /// </summary>
        [Required]
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
        /// The named insured's application id.
        /// </summary>
        [Required]
        public int ApplicationId { get; set; }
    }
}