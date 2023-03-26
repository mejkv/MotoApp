using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sql;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<MotoAppDbContext>(options => options
.UseSqlServer("Data Source=DESKTOP-IF9KOVP\\SQLEXPRESS01;" +
                "Initial Catalog=MotoAppStorage;" +
                "Integrated Security=True;" +
                "Trust Server Certificate=True"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();




