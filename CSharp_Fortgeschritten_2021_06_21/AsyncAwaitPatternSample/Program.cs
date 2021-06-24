using System;
using System.Threading.Tasks;

namespace AsyncAwaitPatternSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Ohne Returnwerten
            //Ohne Returnwerten
            Task easyTask = Task.Run(MethodeOhneReturnwert);
            easyTask.Wait();


            // Mit asyn/await

            await Task.Run(MethodeOhneReturnwert);
            //WICHTIG! Wenn wir await innerhalb einer Methode verwenden, muss in der MEthoden-Signatur ein async hinzugefügt werden. 
            #endregion



            //Mit Returnwerten
            Task<string> taskWithReturnValue = Task.Run(MethodeMitReturnwert);
            taskWithReturnValue.Wait();
            string returnwert = taskWithReturnValue.Result;


            string returnString = await Task.Run(MethodeMitReturnwert); //Wenn Taks fertig ist, wird returnString einen Rückgabewert erhalten
        }


        public static void MethodeOhneReturnwert()
        {
            //Mach was
        }

        public static string MethodeMitReturnwert()
        {
            return DateTime.Now.ToString();
        }
    }
}
