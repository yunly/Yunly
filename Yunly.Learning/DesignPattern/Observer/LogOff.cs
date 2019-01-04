using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Observer
{
    public class LogOff<Press> : IDisposable
    {
        private List<IObserver<Press>> observers;
        private IObserver<Press> observer;

        public LogOff(List<IObserver<Press>> observers, IObserver<Press> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            observers.Remove(observer);
        }
    }
}
