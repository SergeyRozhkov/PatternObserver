using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    class Observable : IObservable<string>
    {
        private List<IObserver<string>> _observers;

        public Observable()
        {
            _observers = new List<IObserver<string>>();
        }
        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (observer != null)
                _observers.Add(observer);
            return new Unsubscribe(observer, _observers);
        }

        public void NotifyObservers(string str)
        {
            foreach (var observer in _observers)
                observer.OnNext(str);
        }
    }

    class Unsubscribe : IDisposable
    {
        private List<IObserver<string>> _observers;
        private IObserver<string> _observer;

        public Unsubscribe(IObserver<string> observer, List<IObserver<string>> observers)
        {
            _observer = observer;
            _observers = observers;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
