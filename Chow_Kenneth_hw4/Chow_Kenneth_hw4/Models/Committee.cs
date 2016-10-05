using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chow_Kenneth_hw4.Models
{
    public class Committee
    {

        public Int32 CommitteeID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter the committee name")]
        public String CommitteeName { get; set; }
    }
}