using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Observer
{
    public class BaggageInfo
    {
        internal BaggageInfo(int flight, string from, int carousel)
        {
            this.FlightNumber = flight;
            this.From = from;
            this.Carousel = carousel;
        }

        public int FlightNumber { get; private set; }        
        public string From { get; private set; }
        public int Carousel { get; private set; }
    }
}
