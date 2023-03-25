using MotoApp.Components.CsvReader;
using System.Xml.Linq;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;


        public App(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public void Run() 
        {
            CreateXml();
            QuerryXml();
        }

        private static void QuerryXml()
        {
            var document = XDocument.Load("fuel.xml");
            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
                .Select(x => x.Attribute("Name")?.Value);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private void CreateXml()
        {
             var records = _csvReader.ProcessCars("Resources\\fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars", records
                .Select(x =>
                new XElement("Car",
                    new XAttribute("Name", x.Name),
                    new XAttribute("Combined", x.Combined),
                    new XAttribute("Manufacturer", x.Manufactured))));

            document.Add(cars);
            document.Save("fuel.xml");
        }
    }
}
