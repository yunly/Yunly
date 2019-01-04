using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Observer
{
    public class PressHandler : IObservable<Press>
    {
        private List<IObserver<Press>> observers = new List<IObserver<Press>>();
        private List<Press> presses = new List<Press>();

        public IDisposable Subscribe(IObserver<Press> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);

                foreach (var press in presses)
                    observer.OnNext(press);
            }

            return new LogOff<Press>(observers, observer);
        }

        public void Publish(Press press)
        {
            presses.Add(press);
            foreach (var observer in observers)
                observer.OnNext(press);
        }

        public void LastPressPublished()
        {
            foreach (var observer in observers)
                observer.OnCompleted();

            observers.Clear();
        }
        


    }
}
