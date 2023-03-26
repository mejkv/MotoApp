using MotoApp.Data;
using MotoApp.Components.CsvReader;
using MotoApp.Data.Entities;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;
        private readonly MotoAppDbContext _motoAppDbContext;

        public App(MotoAppDbContext motoAppDbContext, ICsvReader csvReader)
        {
            _csvReader = csvReader;
            _motoAppDbContext = motoAppDbContext;
            _motoAppDbContext.Database.EnsureCreated();
        }

        public void Run()
        {
            
            
            

            var cayman = this.ReadFirst("Cayman");
            cayman.Name = "Mój samochód";
            _motoAppDbContext.SaveChanges();
        }

        private Car? ReadFirst(string name)
        {
            return _motoAppDbContext.Cars.FirstOrDefault(c => c.Name == name);
        }

        private void AppUI()
        {
            bool exit = false;
            while (true)
            {

                Console.WriteLine("==========================================");
                Console.WriteLine("Welcome in (description will do tomorrow) ");
                Console.WriteLine("==========================================");
                Console.WriteLine("Choose option (1/2/3");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Insert data");
                Console.WriteLine("2. Read all cars from database");
                Console.WriteLine("3. Read grouped cars from database");
                Console.WriteLine("4. Modify car name");
                Console.WriteLine("5. Remove data");
                Console.WriteLine("To finish click 'Q'");
                Console.WriteLine("==========================================");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        InsertData();
                        break;

                    case "2":
                        ReadAllCarsFromDb();
                        break;

                    case "3":
                        ReadGroupedCarsFromDb();
                        break;

                    case "4":
                        ModifyCarNameFromDb();
                        break;

                    case "5":
                        RemoveCar();
                        break;

                    case "Q" or "q":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid operation\n");
                        break;

                }
            }
        }

        private void ModifyCarNameFromDb()
        {
            Console.WriteLine("Choose car name to change");
            var getNameFromUser = Console.ReadLine();
            var cayman = this.ReadFirst(getNameFromUser);

            Console.WriteLine("Give new name");
            var newNameFromUser = Console.ReadLine();
            cayman.Name = newNameFromUser;
            _motoAppDbContext.SaveChanges();
        }

        private void RemoveCar()
        {
            Console.WriteLine("Give car name to remove");
            var getNameFromUser = Console.ReadLine();
            var cayman = this.ReadFirst(getNameFromUser);
            _motoAppDbContext.Cars.Remove(cayman);
            _motoAppDbContext.SaveChanges();
        }

        private void ReadGroupedCarsFromDb()
        {
            var groups = _motoAppDbContext
                .Cars
                .GroupBy(x => x.Manufactured)
                .Select(x => new
                {
                    Name = x.Key,
                    Cars = x.ToList()
                }) 
                .ToList();

            foreach ( var group in groups )
            {
                Console.WriteLine(group.Name);
                Console.WriteLine("========");
                foreach ( var car in group.Cars )
                {
                    Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }
        }


        private void ReadAllCarsFromDb()
        {
            var carsFromDb = _motoAppDbContext.Cars.ToList();

            foreach (var carFromDb in carsFromDb)
            {
                Console.WriteLine($"\t {carFromDb.Name}: {carFromDb.Combined}");
            }
        }

        private void InsertData()
        {
            var cars = _csvReader.ProcessCars("Resources\\fuel.csv");

            foreach (var car in cars)
            {
                _motoAppDbContext.Cars.Add(new Car()
                {
                    Manufactured = car.Manufactured,
                    Name = car.Name,
                    Year = car.Year,
                    City = car.City,
                    Combined = car.Combined,
                    Cylinders = car.Cylinders,
                    Displacement = car.Displacement,
                    Highway = car.Highway,
                });
            }

            _motoAppDbContext.SaveChanges();
        }
    }
}
