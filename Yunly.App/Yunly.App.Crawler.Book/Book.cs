using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.App.Crawler.Book
{
    public class Book
    {
        public string Title { get; set; }

        List<Chapter> Chapters = new List<Chapter>();

        class Chapter
        {
            public int Sequence { get; } = 1;
            public string Head { get; set; }
            public bool hasSubChapter { get; set; }
            public string content { get; set; }
            public Chapter SubChapter { get; set; }
        }

        public int addChapters(string head, string content)
        {
            return 1;
        }

    }
}
