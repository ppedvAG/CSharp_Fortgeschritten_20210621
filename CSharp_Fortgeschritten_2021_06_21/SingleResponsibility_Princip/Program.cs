using System;

namespace SingleResponsibility_Princip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region Schlechtes Beispiel
    public class EmployeeBad
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(EmployeeBad em)
        {
            // Insert into employee table.
            return true;
        }


        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(EmployeeBad em)
        {
            // Report generation with employee data using crystal report.


            #region CS
            // Konfigurationen
            //  -> Wo liegen Templates eine Reports
            //  -> Ausgabeverzeichnis der Reports mit eventuell Zeit-Intervallen (Ausgabe Steuern) 

            //Core
            // Verarbeitung von einem DataTable / IList / List / Dictionary von Daten -> Report erstellt 
            #endregion

        }

        // GenerateReport wird in einer eigene Klasse ausgelagert, weil GenerateReport eine eigene Funktionalität mit sich bringt.
    }
    #endregion


    #region Better Variant
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
    }


    public class ReportGenerator 
    {
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            // Report reneration with employee data.
        }
    }


    public class EmployeeRepository
    {
        public bool InsertIntoEmployeeTable(Employee em)
        {
            // Insert into employee table.
            return true;
        }
    }


    public class MyProgramm
    {

    }

    #endregion


}
