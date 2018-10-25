using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            var observable = new Observable();

            var observer1 = new Observer();
            var observer2 = new Observer();
            var observer3 = new Observer();

            observer1.Subscribe(observable);
            observer2.Subscribe(observable);
            observer3.Subscribe(observable);

            observable.NotifyObservers("Hello");
            Console.WriteLine();
            observable.NotifyObservers("Good");
            Console.WriteLine();

            observer2.OnCompleted();

            observable.NotifyObservers("...");
            Console.ReadKey();
        }
    }
}
