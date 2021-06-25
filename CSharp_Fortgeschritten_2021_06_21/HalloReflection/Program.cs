using System;
using System.Reflection;

namespace HalloReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly geladeneDll = Assembly.LoadFrom("TrumpTaschenrechner.dll");

            Type trumpTaschenrechnerTyp = geladeneDll.GetType("TrumpTaschenrechner.Taschenrechner");

            object tr = Activator.CreateInstance(trumpTaschenrechnerTyp);

            MethodInfo addInfo = trumpTaschenrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });


            var result = addInfo.Invoke(tr, new object[] { 33, 11 });

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
