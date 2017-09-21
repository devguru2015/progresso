using System.ComponentModel.DataAnnotations;

namespace Polgresso.PolicyMaker.Entities
{
    public enum MartialStatus
    {
        [Display(Name = "Single")]
        S,

        [Display(Name = "Married")]
        M
    }
}