using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStore.Models
{
    public enum Gender
    {
        [Display(Name = "Other")]
        Other,

        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female
    }
}
