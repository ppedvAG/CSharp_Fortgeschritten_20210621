using System;

namespace DelegatesActionsFuncSample
{
    class Program
    {

        delegate int NumbChange(int num);
        delegate void NumbChange2(int a, int b, int c);

        static void Main(string[] args)
        {
            #region Delegate Einstieg
            //Beispiel 1
            NumbChange nc1 = new NumbChange(Add12);
            int result = nc1(11); //reuslt = 23
            
            
            //Beispiel 2: zweite Methode mit hinzugüfen
            nc1 += Sub17;

            result = nc1(20);
            nc1 -= Sub17;
            result = nc1(20); //Es ist nur noch Add12 vorhanden. 
            #endregion


            #region Action Delegate

            //Beispiel mit MEthode ohne Parameter und Rückgabewert
            Action a1 = new Action(VoidMethodeWithoutParams);
            a1();
            
            //Action hat keinen Rückgabewert
            // Action kann 16 Paramter abbilden. 
            Action<int, int, int> a2 = AddNums;
            a2(22, 12, 8); //Ergebnis wäre 42

            //Delegate wäre etwas mehr Aufwand -> schlechtere DelegateVariabte
            
            NumbChange2 nc2 = new NumbChange2(AddNums);
            nc2(20, 30, 44);

            Func<int, int, int> func = Addition;

            int result3 = func(12, 11);

        }


        #region Delegate-Beispiel Methoden
        private static int Add12(int num)
        {
            return num + 12;
        }
        private static int Sub17(int num)
        {
            return num - 17;
        }
        #endregion

        #region Action Methoden
        public static void VoidMethodeWithoutParams()
        {
            Console.WriteLine("Hello world!");
        }


        public static void AddNums(int a, int b, int c)
        {
            Console.WriteLine($"{ a + b + c}");
        }
        #endregion

        #region Func
        public static int Addition(int z1, int z2)
        {
            return z1 + z2;
        }
        #endregion
    }
}
