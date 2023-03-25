using System;
using System.Linq;
using System.Text;
using MotoApp.Components.DataProviders.Extensions;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

namespace MotoApp.Components.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;

        public CarsProvider(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<string> GetUniqueCarColors()
        {
            var cars = _carsRepository.GetAll();
            var colors = cars.Select(c => c.Color).Distinct().ToList();
            return colors;
        }

        public decimal GetMinimumPriceOfAllCars()
        {
            var cars = _carsRepository.GetAll();
            return cars.Select(x => x.ListPrice).Min();
        }

        public List<Car> GetSpecificColumns()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new Car
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
            }).ToList();

            return list;
        }

        public string AnonymousClass()
        {
            var cars = _carsRepository.GetAll();

            var list = cars.Select(car => new
            {
                Identifier = car.Id,
                ProductName = car.Name,
                ProductType = car.Type,
            });

            StringBuilder sb = new(1024);
            foreach (var car in list)
            {
                sb.AppendLine($"Product ID: {car.Identifier}");
                sb.AppendLine($"   Product Name: {car.ProductName}");
                sb.AppendLine($"   Product Type: {car.ProductType}");
            }

            return sb.ToString();
        }

        public List<Car> OrderByName()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderBy(x => x.Name).ToList();
        }

        public List<Car> OrderByNameDescending()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(x => x.Name).ToList();
        }

        public List<Car> OrderByColorAndName()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Color)
                .ThenBy(x => x.Name)
                .ToList();
        }

        public List<Car> OrderByColorAndNameDesc()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderByDescending(x => x.Color)
                .ThenByDescending(x => x.Name)
                .ToList();
        }

        public List<Car> WhereStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
        }

        public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(x => x.Name.StartsWith(prefix) && x.StandartCost > cost).ToList();
        }

        public List<Car> WhereColorIs(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.ByColor("Red").ToList();
        }

        public Car FirstByColor(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.First(x => x.Color == color);
        }

        public Car FirstByColorOrDefault(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.FirstOrDefault(x => x.Color == color);
        }

        public Car? FirstOrDefaultByColorWithDefault(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.FirstOrDefault(x => x.Color == color,
                new Car { Id = -1, Name = "NOT FOUND" });
        }

        public Car LastByColor(string color)
        {
            var cars = _carsRepository.GetAll();
            return cars.Last(x => x.Color == color);
        }

        public Car SingleById(int id)
        {
            var cars = _carsRepository.GetAll();
            return cars.Single(x => x.Id == id);
        }

        public Car? SingleOrDefaultById(int id)
        {
            var cars = _carsRepository.GetAll();
            return cars.SingleOrDefault(x => x.Id == id);
        }

        public List<Car> TakeCars(int howMany)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Take(howMany)
                .ToList();
        }

        public List<Car> TakeCars(Range range)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Take(range)
                .ToList();
        }

        public List<Car> TakeCarsWithNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<Car> SkipCars(int howMany)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .Skip(howMany)
                .ToList();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .OrderBy(x => x.Name)
                .SkipWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<string> DistinctAllColors()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public List<Car> DistinctByColor()
        {
            var cars = _carsRepository.GetAll();
            return cars
                .DistinctBy(x => x.Color)
                .OrderBy(c => c)
                .ToList();
        }

        public List<Car[]> ChunkChars(int size)
        {
            var cars = _carsRepository.GetAll();
            return cars.Chunk(size).ToList();
        }

        public List<Car> SkipAndTake(int howManySkip, int howManyTake)
        {
            var cars = _carsRepository.GetAll();
            return cars
                .Skip(howManySkip)
                .Take(howManyTake)
                .ToList();
        }
    }
}