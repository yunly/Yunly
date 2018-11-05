using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yunly.Education.Models
{
    public class Course
    {
        public string courseName { get; set; }
        public string location { get; set; }
        public decimal price { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
