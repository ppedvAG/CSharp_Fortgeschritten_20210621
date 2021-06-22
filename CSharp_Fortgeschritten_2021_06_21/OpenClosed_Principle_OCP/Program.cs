using System;
using System.Collections.Generic;

namespace OpenClosed_Principle_OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgrammOpenClose programmOpenClose = new ProgrammOpenClose();
            programmOpenClose.Main();
            Console.ReadKey();
        }
    }


    #region BadCode
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
    }


    public class ReportGenerator
    {
        /// <summary>
        /// Report type
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                //Libary für PDF Export
                //Fülllogik us
                // Report generation with employee data in PDF.
            }
        }
    }
    #endregion

    #region BetterVariantA mit abstrakter Klasse











    //Open Part -> Abstraktion -> abstract class oder mit Interface
    public abstract class ReportGeneratorBase 
    {
        public abstract void ReportGenerator(Employee em);
    }








    //Close-Part
    public class CrstalReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            // Generatore crystal report
        }

        //Weitere ptivate - Methoden zu CrystalReports sind auch möglich
    }

    //Close-Part
    public class PDFReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            // Genrator für PDF Report
        }
    }

    public class List10ReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            // Genrator für PDF Report
        }
    }



    public class ProgrammOpenClose
    {
        public void Main()
        {
            IList<ReportGeneratorBase> myReports = new List<ReportGeneratorBase>();

            myReports.Add(new PDFReportGenerator());
            myReports.Add(new CrstalReportGenerator());
            myReports.Add(new CrstalReportGenerator());
            myReports.Add(new PDFReportGenerator());
            myReports.Add(new List10ReportGenerator());
            Employee employee = new Employee() { Employee_Id = 1, Employee_Name = "Hannes" };
            
            
            
            foreach (var current in myReports)
            {
                current.ReportGenerator(employee);
            }
        }
    }
    #endregion




    #region mit Interface

    public interface IGenerator
    {
        void GenerateReport(Employee employee);
    }

    public class PDFGenerator : IGenerator
    {
        public void GenerateReport(Employee employee)
        {
        }
    }

    public class CSGenerator : IGenerator
    {
        public void GenerateReport(Employee employee)
        {
        }
    }

    public class MyProgramm
    {
        public void Main()
        {
            Employee employee = new Employee();

            IGenerator selectedGenerator = null;

            //if (auswahl == 1)
            //    selectedGenerator = new PDFGenerator();



            IGenerator pdfGenerator = new PDFGenerator();
            IGenerator csGenerator = new CSGenerator();

            pdfGenerator.GenerateReport(employee);
            csGenerator.GenerateReport(employee);
        }
    }

    #endregion
}
