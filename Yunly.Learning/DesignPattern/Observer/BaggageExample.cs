using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Observer
{
    public class BaggageExample
    {
        public static void run()
        {
            BaggageHandler provider = new BaggageHandler();
            ArrivalsMonitor observer1 = new ArrivalsMonitor("BaggageClaimMonitor1");
            ArrivalsMonitor observer2 = new ArrivalsMonitor("SecurityExit");

            observer1.Subscribe(provider);
            provider.BaggageStatus(712, "Detroit", 3);
            provider.BaggageStatus(712, "Kalamazoo", 3);
            provider.BaggageStatus(400, "New York-Kennedy", 1);
            provider.BaggageStatus(712, "Detroit", 3);

            observer2.Subscribe(provider);

            provider.BaggageStatus(511, "San Francisco", 2);
            provider.BaggageStatus(712);
            observer2.Unsubscribe();

            provider.BaggageStatus(400);

            provider.LastBaggageClaimed();
        }
    }
}
