using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Profiles;
using RestaurantReservation.Repositories.CustomerRepositories;
using RestaurantReservation.Repositories.EmployeeRepositories;
using RestaurantReservation.Repositories.RestaurantRepositories;
using RestaurantReservation.Services.CustomerServices;
using RestaurantReservation.Services.EmployeeServices;
using RestaurantReservation.Services.RestaurantServices;

namespace RestaurantReservation.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(RestaurantProfile));
        serviceCollection.AddAutoMapper(typeof(CustomerProfile));
        serviceCollection.AddAutoMapper(typeof(EmployeeProfile));
        serviceCollection.AddTransient<IRestaurantService, RestaurantService>();
        serviceCollection.AddTransient<ICustomerService, CustomerService>();
        serviceCollection.AddTransient<IEmployeeService, EmployeeService>();

    }

    public static void AddDataAccessServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<RestaurantReservationDbContext>();
        serviceCollection.AddTransient<IRestaurantRepository, RestaurantRepository>();
        serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
        serviceCollection.AddTransient<IEmployeeRepository, EmployeeRepository>();

    }
}