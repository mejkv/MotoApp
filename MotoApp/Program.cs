
using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
WriteToConsole(employeeRepository);


static void AddEmployees(IRepository<Employee> repository)
{
    var employees = new[]
    {
        new Employee {FirstName = "Adam"},
        new Employee {FirstName = "Piotr"},
        new Employee {FirstName = "Zuza"}
    };

    repository.AddBatch(employees);
    //employeeRepository.Add(new Employee { FirstName = "Michał" });
    //employeeRepository.Add(new Employee { FirstName = "Miki" });
    //employeeRepository.Add(new Employee { FirstName = "Mietek" });
    //employeeRepository.Save();
}

//static void AddBatch<T>(IRepository<T> repository, T[] items) 
//    where T : class, IEntity
//{
//    foreach (var employee in items)
//    {
//        repository.Add(employee);
//    }

//    repository.Save();
//}

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Malwina" });
    managerRepository.Add(new Manager { FirstName = "Magda" });
    managerRepository.Save();
}

static void WriteToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}