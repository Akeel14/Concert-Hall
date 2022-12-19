using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2022A1AL.Models
{
    public class VenueEditFormViewModel
    {
        [Key]
        public int VenueId { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Date Opened")]
        public DateTime? OpenDate { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(5)]
        [RegularExpression("[A-Z]{2}[0-9]{3}", ErrorMessage = " must contain the format “LLNNN” where “L” represents a capital letter and “N” represents a number(0 - 9).For example, “XY123”.")]
        public string PromoCode { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Range(1, 50000, ErrorMessage = "Please enter an integer between 1 and 50,000")]

        public int Capacity { get; set; }

      
    }
}