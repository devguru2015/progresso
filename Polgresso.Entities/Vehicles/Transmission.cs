using System.ComponentModel.DataAnnotations;

namespace Polgresso.Entities.Vehicles
{
    public enum Transmission
    {
        [Display(Name = "Automatic")]
        A,

        [Display(Name = "Manual")]
        M
    }
}