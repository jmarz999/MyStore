using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "InProcess")]
        InProcess,
        [Display(Name = "Done")]
        Done
    }
}