using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Product> OwnProducts { get; set; }
    }
}
