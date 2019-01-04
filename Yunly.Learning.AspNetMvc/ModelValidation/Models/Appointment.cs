﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ModelValidation.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Display(Name ="name")]
        public string ClientName { get; set; }

        
        [UIHint("Date")]
        [Required(ErrorMessage ="Please enter a date")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }
        
        //[Range(typeof(bool),"true","true", ErrorMessage ="You must accept the terms")]
        [MustBeTrue(ErrorMessage ="You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}
