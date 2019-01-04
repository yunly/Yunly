using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Observer
{
    public class Press
    {
        public string Name { get; private set; }
        public string Publisher { get; private set; }
        public DateTime PublishDate { get; set; }


        public Press(string name, string publisher, DateTime date)
        {
            this.Name = name;
            this.Publisher = publisher;
            this.PublishDate = date;
        }

        public override string ToString()
        {
            return $"{Publisher}: {Name}, {PublishDate.ToShortDateString()}";
        }
    }
}
