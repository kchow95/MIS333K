using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace chow_kenneth_hw4_2.Models
{
    public class Event
    {
        public Int32 EventID { get; set; }

        [Required(ErrorMessage = "Please enter the event title")]
        public String Title { get; set; }

        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter the date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Event Location")]
        [Required(ErrorMessage = "Please enter the location")]
        public String Location { get; set; }

        [Display(Name = "Members Only")]
        public Boolean MembersOnly { get; set; }

        [Display(Name = "Sponsoring Committee")]
        public virtual Committee SponsoringCommittee { get; set; }
        public virtual List<Member> Members { get; set; }

    }
}