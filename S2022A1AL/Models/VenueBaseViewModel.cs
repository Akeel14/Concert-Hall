﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2022A1AL.Models
{
    public class VenueBaseViewModel : VenueAddViewModel
    {
        [Key]
        public int VenueId { get; set; }
    }
}