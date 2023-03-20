﻿
using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
employeeRepository.ItemAdded += employeeRepositoryOnItemAdded;

void employeeRepositoryOnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
}

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
}

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