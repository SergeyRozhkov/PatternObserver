using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    class Observer : IObserver<string>
    {
        public readonly int ID;

        private static int _id = 1;
        private IDisposable _unsubscribe;

        public Observer()
        {
            ID = _id;
            _id++;
        }
        public void Subscribe(IObservable<string> observable)
        {
            if (observable != null)
                _unsubscribe = observable.Subscribe(this);
        }

        public void OnCompleted()
        {
            Unsubscribe();
        }

        public void OnError(Exception error)
        {
            throw new Exception("Ошибка: " + error.Message);
        }

        public void OnNext(string str)
        {
            Console.WriteLine("Подписчик {0} получил строчку {1}", ID, str);
        }

        private void Unsubscribe()
        {
            _unsubscribe.Dispose();
        }
    }
}
