using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using HelloSerialize.CSV;

namespace HelloSerialize
{
    class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 64,
                Kontostand = 100_000,
                Kreditlimit = 500_000
            };

            Stream stream = null;

            #region Binär
            //SCHREIBEN VON BINÄREN DATEN
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //stream = File.OpenWrite("Person.bin");
            //binaryFormatter.Serialize(stream, person);
            ////stream.Flush();
            //stream.Close();

            //LESEN VON BINÄREN DATEN
            //stream = File.OpenRead("Person.bin");
            //Person geladenePerson = (Person)binaryFormatter.Deserialize(stream);
            //stream.Close();
            #endregion

            #region XML
            //SCHREIBEN VON XML DATEN
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();

            //LESEN VON XML DATEN
            stream = File.OpenRead("Person.xml");

            Person geladenePersonAusXML = (Person)xmlSerializer.Deserialize(stream);

            #endregion

            #region JSON - System.Text.Json;
            //SCHREIBEN VON JSON
            string jsonString = System.Text.Json.JsonSerializer.Serialize(person);
            File.WriteAllText("person.json", jsonString);

            //LESEN VON JSON
            string gelesenerJsonString = File.ReadAllText("person.json");
            Person geladenePerson2 = (Person)System.Text.Json.JsonSerializer.Deserialize(gelesenerJsonString, typeof(Person));
            #endregion

            #region JSON - Newtonsoft.JSON

            //SCHREIBEN VON JSON
            jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(person);
            File.WriteAllText("person1.json", jsonString);

            gelesenerJsonString = string.Empty;
            gelesenerJsonString = File.ReadAllText("person1.json");
            Person jsonPerson = JsonConvert.DeserializeObject<Person>(gelesenerJsonString);
            #endregion


            #region Eigener CSVSerializer
            person.Serialize("Person.csv");

            Person gelandenePersonAusCSV = new Person();
            gelandenePersonAusCSV.Deserialize("Person.csv");


            #endregion



            Console.ReadKey();
        }
    }

    [Serializable] //Für Person
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }




        [field: NonSerialized]//Bei Properties 
        public decimal Kontostand { get; set; }


        [NonSerialized()] //Bei Variablen wird NonSerialized verwendet
        public decimal Kreditlimit;


    }
}
