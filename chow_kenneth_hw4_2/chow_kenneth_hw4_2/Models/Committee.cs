using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace chow_kenneth_hw4_2.Models
{
    public class Committee
    {
        public Int32 CommitteeID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter the committee name")]
        public String CommitteeName { get; set; }
    }
}