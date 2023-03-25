using MotoApp.Components.CsvReader.Extensions;
using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Car> ProcessCars(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Car>();
            }

            var cars = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToCar();

            return cars.ToList();
        }

        public List<Manufactures> ProcessManufactures(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Manufactures>();
            }

            var cars = 
                File.ReadAllLines(filePath)
                .Where(x => x.Length > 1)
                .Select(x =>
                {
                    var colums = x.Split(',');
                    return new Manufactures()
                    {
                        Name = colums[0],
                        Country = colums[1],
                        Year = int.Parse(colums[2])
                    };
                });

            return cars.ToList();
        }
    }
}
