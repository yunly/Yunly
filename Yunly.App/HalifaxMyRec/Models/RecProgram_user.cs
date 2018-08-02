using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yunly.App.Crawler.HalifaxMyRec.Models
{
    public partial class RecProgram
    {
        [NotMapped]
        public IList<int> DaysOfWeek { get; set; }

        public override string ToString()
        {
            return null;
            //return string.Format("{0},{1},{2},{3}", Location, Name, StartDateFormatted, NextSessionStartDateFormatted);
        }
    }
}
