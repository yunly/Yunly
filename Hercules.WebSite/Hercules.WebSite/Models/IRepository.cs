using System;
using System.Collections.Generic;
using System.Text;

namespace Hercules.WebSite.Models
{
    public interface IRepository
    {
        IEnumerable<string> urls { get; }
    }
}
