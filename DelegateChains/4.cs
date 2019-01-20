using System;

namespace DelegateChains
{
    internal delegate void Notify(string message); //Notify 대리자 선언

    internal class Notifier
    {
        //Notify대리자의 인스턴스 EventOccured를 가지는 클래스 Notifier선언
        public Notify EventOccured;
    }

    internal class EventLister
    {
        private string name;

        public EventLister(string name)
        {
            this.name = name;
        }

        public void SomethingHappend(string message)
        {
            Console.WriteLine($"{name}.SometingHappend: {message}");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventLister listener1 = new EventLister("Listener1");
            EventLister listener2 = new EventLister("Listener2");
            EventLister listener3 = new EventLister("Listener3");

            notifier.EventOccured += listener1.SomethingHappend;
            notifier.EventOccured += listener2.SomethingHappend;
            notifier.EventOccured += listener3.SomethingHappend;
            notifier.EventOccured("You'v got mail.");
        }
    }
}