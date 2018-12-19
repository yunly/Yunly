using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cities.Models
{
    public class City
    {
        [Display(Name = "City")]
        public string Name { get; set; }
        public string Country { get; set; }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-2.2
        /// </summary>
        [DisplayFormat(DataFormatString ="{0:F2}", ApplyFormatInEditMode =true)]
        public int? Population { get; set; }
    }
}
