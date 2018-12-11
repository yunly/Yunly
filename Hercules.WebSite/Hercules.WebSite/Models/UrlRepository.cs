using System;
using System.Collections.Generic;
using System.Text;
using Hercules.WebSite;

namespace Hercules.WebSite.Models
{
    public class UrlRepository : IRepository
    {
        private readonly List<string> pageIds;
        private readonly WordPrss wordPress;

        public UrlRepository(List<string> pageIds, WordPrss wordPress)
        {
            this.pageIds = pageIds;
            this.wordPress = wordPress;
        }

        public IEnumerable<string> urls {
            get
            {
                foreach (var pageId in pageIds)
                {
                    yield return wordPress.BuildUrl(pageId);
                }
            }
        }
    }
}
