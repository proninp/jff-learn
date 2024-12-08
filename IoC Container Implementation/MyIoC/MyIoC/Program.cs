using MyIoC.DependencyInjection;
using MyIoC.Services;

var services = new DIServiceCollection();

services.RegisterSingleton<DataProvider>();

services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();
services.RegisterTransient<IRegularService, RegularService>();

var container = services.BuildContainer();

var firstDataProvider = container.GetRequiredService<DataProvider>();
var secondDataProvider = container.GetRequiredService<DataProvider>();

var regularService1 = container.GetRequiredService<IRegularService>();
var regularService2 = container.GetRequiredService<IRegularService>();

Console.WriteLine($"First: {firstDataProvider.Uuid}");
Console.WriteLine($"Second: {secondDataProvider.Uuid}");

regularService1.Print();
regularService2.Print();