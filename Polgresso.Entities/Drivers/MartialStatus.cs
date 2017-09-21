using System.ComponentModel.DataAnnotations;

namespace Polgresso.Entities.Drivers
{
    public enum MartialStatus
    {
        [Display(Name = "Single")]
        S,

        [Display(Name = "Married")]
        M
    }
}