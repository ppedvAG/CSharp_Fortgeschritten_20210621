using System;

namespace EventAndEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogicComponent pbl = new ProcessBusinessLogicComponent();
            pbl.ProcessInWorking += Pbl_ProcessInWorking;
            pbl.ProcessCompleted += Pbl_ProcessCompleted;

            pbl.StartProces();


            ProcessBusinessLogicComponent2 pbl2 = new ProcessBusinessLogicComponent2();
            pbl2.ProcessCompleted += Pbl2_ProcessCompleted;
            pbl2.ProcessCompletedNew += Pbl2_ProcessCompletedNew;
            pbl2.Start();



        }

        private static void Pbl2_ProcessCompletedNew(object sender, EventArgs e)
        {
            if (e is not MyEventArg)
                return; //Exception ist auch gut. 


            MyEventArg myEventArg = (MyEventArg)e;

            Console.WriteLine($"Bin fertig {myEventArg.Uhrzeit.ToString()}");
        }

        private static void Pbl2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Bin Fertig!");
        }


        #region ProcessBuisnessLogicComponent1
        private static void Pbl_ProcessCompleted()
        {
            
        }

        private static void Pbl_ProcessInWorking(int processBarValue)
        {
            Console.WriteLine("EventAndEventHandler.Programm: " + processBarValue);
        }

        #endregion

    }
}
