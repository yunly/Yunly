using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Observer
{
    public class Kiosk : IObserver<Press>
    {
        public string Name { get; private set; } = "Kiosk" + DateTime.Now.Ticks;

        private List<Press> subscribedPresses = new List<Press>();


        public Kiosk(string name)
        {
            this.Name = name;
        }

        private IDisposable cancelation;

        public void Subscriber(PressHandler provider)
        {
            cancelation = provider.Subscribe(this);
        }

        public void Unscriber()
        {
            cancelation.Dispose();
        }


        public void OnCompleted()
        {
            subscribedPresses.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Press press)
        {
            if (!subscribedPresses.Contains(press))
            {
                subscribedPresses.Add(press);
                Console.WriteLine($"{Name} received {press}");
            }
        }

        public void printSubscribedList()
        {
            Console.WriteLine($"{Name} subscriber list:");
            foreach (var press in subscribedPresses)
            {
                Console.WriteLine($"\t{press}");
            }
        }


        public static void run()
        {
            var kiosk1 = new Kiosk("Wulin Guangchang");
            var kiosk2 = new Kiosk("Jiangling Station");

            PressHandler publisher = new PressHandler();

            kiosk1.Subscriber(publisher);
            kiosk2.Subscriber(publisher);

            publisher.Publish(new Press("Citi Express", "Hangzhou Express", new DateTime(2019, 1, 1)));
            publisher.Publish(new Press("Qianjiang Evening", "Hangzhou Express", new DateTime(2019, 1, 1)));
            publisher.Publish(new Press("Zhejiang Daily", "Zhejiang Express", new DateTime(2019, 1, 1)));

            kiosk2.Unscriber();

            publisher.Publish(new Press("Citi Express", "Hangzhou Express", new DateTime(2019, 1, 2)));
            publisher.Publish(new Press("Qianjiang Evening", "Hangzhou Express", new DateTime(2019, 1, 2)));
            publisher.Publish(new Press("Zhejiang Daily", "Zhejiang Express", new DateTime(2019, 1, 2)));


            kiosk1.printSubscribedList();
            kiosk2.printSubscribedList();

            publisher.LastPressPublished();

            kiosk1.printSubscribedList();
            kiosk2.printSubscribedList();

        }
    }
}
