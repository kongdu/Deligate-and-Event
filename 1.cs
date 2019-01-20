//Delegate
//1. 대리자 선언 2. 대리자의 인스턴스생성 3. 대리자호출
using System;

namespace Deligate
{
    internal delegate int Mydelegate(int a, int b); //대리자 선언

    internal class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }

    internal class MainApp
    {
        private static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            //일반 메소드 호출방식
            Console.WriteLine(Calc.Plus(3, 4));  //Plus 메소드호출

            //델리게이트 호출방식
            Mydelegate Callback = new Mydelegate(Calc.Plus);
            Console.WriteLine(Callback(3, 4));
            Callback = new Mydelegate(Calculator.Minus);
            Console.WriteLine(Callback(7, 5));
        }
    }
}