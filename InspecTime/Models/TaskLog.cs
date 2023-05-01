using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace InspecTime.Models
{
    public class TaskLog
    {
        [Key]
        [Display(Name = "ID Number")]
        public string ID { get; set; }

        [Display(Name = "Employee Code")]
        [Required]
        public String EmplNo { get; set; }

        [Display(Name = "Task Number")]
        [Required]
        public String TaskNo { get; set; }

        [Display(Name = "Start Time")]
        [Required]
        [DataType(DataType.DateTime)]
        //[RegularExpression("[0-9]{2}/[0-9]{2}/[0-9]{4}",
        //    ErrorMessage = "Must be in correct format: mm/dd/yyyy")]
        public string StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.DateTime)]
        //[RegularExpression("[0-9]{2}/[0-9]{2}/[0-9]{4}",
        //    ErrorMessage = "Must be in correct format: mm/dd/yyyy")]
        public string EndTime { get; set; }

    }
}