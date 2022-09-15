using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public enum Manufacturers
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Balea")]
        Balea,
        [Display(Name = "Alverde")]
        Alverde,
        [Display(Name = "Essence")]
        Essence,
        [Display(Name = "Maybeline")]
        Maybeline,
        [Display(Name = "Garnier")]
        Garnier,
        [Display(Name = "Siberica")]
        Siberica
    }
}
