using System;

namespace EventTest
{
    internal delegate void EventHandler(string msg); // 대리자선언

    internal class MyNotifier
    {
        public event EventHandler SomethingHappened;   //event 키워드 한정자를 붙여서 SomethingHappend라는 이벤트 선언

        public void DoSomething(int number)
        {
            int temp = number % 10;
            if (temp != 0 && temp % 3 == 0)  //숫자가 3, 6, 9로 끝나는 값이 될때마다 이벤트가 발생하는
            {                               //SomethingHappend 이벤트에서 사용할 이벤트
                                            //EventHandler 대리자 형식과 동일한 메소드 형태로 구현
                SomethingHappened(String.Format("{0} : 짝", number));
            }
        }
    }

    internal class MainApp
    {
        static public void MyHandler(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler); //작성한 이벤트 핸들러 등록
            //notifier.SomethingHappened += MyHandler;

            for (int i = 0; i < 30; i++)
            {
                notifier.DoSomething(i);
                //DoSomething을 호출하면 그 안에있던 SomethingHappened라는 이벤트 발생하고. 그럴때마다 MyHandler가 처리
            }
        }
    }
}