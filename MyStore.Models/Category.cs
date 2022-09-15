using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public enum Category
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Hair")]
        Hair,
        [Display(Name = "Face")]
        Face,
        [Display(Name = "Makeup")]
        Makeup,
        [Display(Name = "Body")]
        Body
    }
}