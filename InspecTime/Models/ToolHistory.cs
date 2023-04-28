using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspecTime.Models
{
    public class ToolHistory
    {
        [Key]

        [Display(Name = "Tool Number")]
        public string ID { get; set; }

        [Display(Name = "Tool Number")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "The tool number must be between 6 and 8 Characters")]
        public string toolNumber { get; set; }

        [Display(Name = "Date Borrowed ")]
        [Required]
        [RegularExpression("[0-9]{2}/[0-9]{2}/[0-9]{4}",
            ErrorMessage = "Must be in correct format: mm/dd/yyyy")]
        public string D_Remove { get; set; }

        [Display(Name = "Promise Return Date")]
        [Required]
        [RegularExpression("[0-9]{2}/[0-9]{2}/[0-9]{4}",
            ErrorMessage = "Must be in correct format: mm/dd/yyyy")]
        public String P_Return { get; set; }

        [Display(Name = "Returned Date")]
        [Required]
        [RegularExpression("[0-9]{2}/[0-9]{2}/[0-9]{4}",
            ErrorMessage = "Must be in correct format: mm/dd/yyyy")]
        public string DateReturned { get; set; }

        [Display(Name = "Work Center")]
        [Required]
        public String WC { get; set; }

        [Display(Name = "Employee Number")]
        [Required]
        public String EmpNo { get; set; }
    }
}