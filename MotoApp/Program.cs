using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;
using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
//services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
//services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
//services.AddSingleton<ICarsProvider, CarsProvider>();
services.AddSingleton<ICsvReader, CsvReader>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();




//using MotoApp.Data;
//using MotoApp.Entities;
//using MotoApp.Repositories;
//using MotoApp.Repositories.Extensions;

//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
//employeeRepository.ItemAdded += employeeRepositoryOnItemAdded;

//void employeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
//}

//AddEmployees(employeeRepository);
//AddManagers(employeeRepository);
//WriteToConsole(employeeRepository);

//bool exit = false;
//while (true)
//{

//    Console.WriteLine("==========================================");
//    Console.WriteLine("Welcome in (description will do tomorrow) ");
//    Console.WriteLine("==========================================");
//    Console.WriteLine("Choose option (1/2/3");
//    Console.WriteLine("==========================================");
//    Console.WriteLine("1. Read all Employees");
//    Console.WriteLine("2. Add new employee");
//    Console.WriteLine("3. Remove employe");
//    Console.WriteLine("To finish click 'Q'");
//    Console.WriteLine("==========================================");
//    var option = Console.ReadLine();

//    switch (option)
//    {
//        case "1":
//            WriteToConsole(employeeRepository);
//            break;

//        case "2":
//            AddEmployees(employeeRepository);
//            break;

//        case "3":
//            break;

//        case "Q" or "q":
//            exit = true;
//            break;

//        default:
//            Console.WriteLine("Invalid operation\n");
//            break;

//    }
//}
//static void AddEmployees(IRepository<Employee> repository)
//{
//    Console.Write("Name: ");
//    var name = Console.ReadLine();
//    var employees = new[]
//    {
//        new Employee {FirstName = name},
//    };

//    repository.AddBatch(employees);
//}

//static void RemoveEmployees(IRepository<Employee> repository)
//{
//    Console.Write("Name: ");
//    var name = Console.ReadLine();
//    var employees = new[]
//    {
//        new Employee {FirstName = name},
//    };

//    repository.RemoveBatch(employees);
//}

//static void AddManagers(IWriteRepository<Manager> managerRepository)
//{
//    managerRepository.Save();
//}

//static void WriteToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}