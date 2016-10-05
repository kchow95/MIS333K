/*Kenneth Chow
9/25/2016
Members class
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chow_Kenneth_hw3.Models
{
    public class Member
    {

        //key for each member
        [Key]
        public int int_MemberID { get; set; }

        ///First name field and is required
        [Required(ErrorMessage = "Please enter your first name")]
        public String str_FName { get; set; }

        /// Last name field and is required
        [Required(ErrorMessage = "Please enter your last name")]
        public String str_LName { get; set; }

        ///Email field required and must have @ and . characters
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid email")]
        public String str_Email { get; set; }

        ///Phone field and is required
        [Required(ErrorMessage = "Please enter your phone number")]
        public String str_Phone { get; set; }

        ///text attribute
        public bool bool_OKToText { get; set; }

        /// Only allows the 6 majors, nothing else allowed
        [Range(1, 6, ErrorMessage = "Please specify your major")]
        public Majors Major { get; set; }
    }
    /*enum for the majors*/
    public enum Majors
    {
        MIS = 1,
        Marketing = 2,
        STM = 3,
        Finance = 4,
        Supply_chain = 5,
        Accounting = 6
    }

}