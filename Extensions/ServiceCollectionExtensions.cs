using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Profiles;
using RestaurantReservation.Repositories.CustomerRepositories;
using RestaurantReservation.Repositories.EmployeeRepositories;
using RestaurantReservation.Repositories.MenuItemRepositories;
using RestaurantReservation.Repositories.RestaurantRepositories;
using RestaurantReservation.Repositories.TableRepositories;
using RestaurantReservation.Services.CustomerServices;
using RestaurantReservation.Services.EmployeeServices;
using RestaurantReservation.Services.MenuItemServices;
using RestaurantReservation.Services.RestaurantServices;
using RestaurantReservation.Services.TableServices;

namespace RestaurantReservation.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(RestaurantProfile));
        serviceCollection.AddAutoMapper(typeof(CustomerProfile));
        serviceCollection.AddAutoMapper(typeof(EmployeeProfile));
        serviceCollection.AddAutoMapper(typeof(TableProfile));
        serviceCollection.AddAutoMapper(typeof(MenuItemProfile));
        
        serviceCollection.AddTransient<IRestaurantService, RestaurantService>();
        serviceCollection.AddTransient<ICustomerService, CustomerService>();
        serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
        serviceCollection.AddTransient<ITableService, TableService>();
        serviceCollection.AddTransient<IMenuItemService, MenuItemService>();
    }

    public static void AddDataAccessServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<RestaurantReservationDbContext>();
        serviceCollection.AddTransient<IRestaurantRepository, RestaurantRepository>();
        serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
        serviceCollection.AddTransient<IEmployeeRepository, EmployeeRepository>();
        serviceCollection.AddTransient<ITableRepository, TableRepository>();
        serviceCollection.AddTransient<IMenuItemRepository, MenuItemRepository>();
    }
}