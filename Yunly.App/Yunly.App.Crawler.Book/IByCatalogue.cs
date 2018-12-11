using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.App.Crawler.Book
{
    public interface IByCatalogue
    {
        string CataloguePageUrl { get; set; }

        List<string> GetAllPages();

    }
}
