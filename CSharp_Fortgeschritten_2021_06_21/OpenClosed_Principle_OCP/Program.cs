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



    #region Sicherheitsmann auf Rummelsplatz


    //DB Strukturen - Stammdaten 


    //POCO ENTITIES -> EF Core - FirstCode Klassen

    #region Entities 
    public class Jahrmarkt
    {
        public int Id { get; set; }
        public string Name { get; set; }

        IList<JahrmarkParzellen> Parzellen { get; set; }
    }

    //Tabellen Parzellen
    public class JahrmarkParzellen
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Jahrmarkt Jarhmarkt { get; set; }
        public int JahrmarktId { get; set; }
    }

    public class SecurityMan
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class Report
    {
        public int Id { get; set; }
        public DateTime ReportTime { get; set; }

        public string Memo { get; set; }
    }


    

    #endregion


    #region Datenzugriffs-Klasen

    public abstract class RepositoryBase<T> 
    {
        //abstracte Methoden Insert/GetAll/Delete/Update 

        //CRUD -> Create/Read/Update/Delete

        public abstract void Insert(T obj);

        //Mit Generic wird die Base-Klasse noch schicker
    }

    public class JahrmarktRepository : RepositoryBase<Jahrmarkt>
    {
        //Datenbank Verbindung-> private SqlConnection (Variante1)
        //Datenbank Verbindung-> private DbContext (Variante1)
        public override void Insert(Jahrmarkt obj)
        {
            throw new NotImplementedException();
        }

        public IList<Jahrmarkt> GetAll()
        {
            return new List<Jahrmarkt>();
        }


        public Jahrmarkt GetById(int Id)
        {
            return new Jahrmarkt();
        }
    }


    public class ParzellenRepository : RepositoryBase<JahrmarkParzellen>
    {
        //Selbe Methoden wie in Jahrmark Repository
        public override void Insert(JahrmarkParzellen obj)
        {
          
        }
    }

    public class SecurityManRepository : RepositoryBase<SecurityMan>
    {
        //Selebe Methoden wie in Jahrmarkt Repository
        public override void Insert(SecurityMan obj)
        {
            throw new NotImplementedException();
        }
    }


    public class ReportRepository : RepositoryBase<Report>
    {
       
        public IList<Report> GetAll()
        {
            return new List<Report>();
        }

        public override void Insert(Report obj)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    
    
    
    
    
    //Workflow -> Sicherheitsmann muss einen Bericht schreiben und speicher
    public class SecurityReport
    {
        public void Report(int JahrmarkId, int SecurityManId, Report newReport)
        {
            ReportRepository repository = new ReportRepository();
            repository.Insert(newReport);
        }
    }


    public class ZeiterfassungSystem
    {
        public void MitarbeiterBeginnArbeit(SecurityMan security)
        {

        }
    }




    #endregion
}
