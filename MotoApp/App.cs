using MotoApp.Components.CsvReader;

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
            Console.WriteLine("Im here");
            Console.WriteLine("########");
            Console.WriteLine("Skip and take");

            var cars = _csvReader.ProcessCars("Resources\\fuel.csv");
            var manufactures = _csvReader.ProcessManufactures("Resources\\manufacturers.csv");
            
        }
    }
}
