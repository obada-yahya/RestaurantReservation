using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Profiles;
using RestaurantReservation.Repositories.RestaurantRepositories;
using RestaurantReservation.Services.RestaurantServices;

namespace RestaurantReservation.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(RestaurantProfile));
        serviceCollection.AddTransient<IRestaurantService, RestaurantService>();
    }

    public static void AddDataAccessServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<RestaurantReservationDbContext>();
        serviceCollection.AddTransient<IRestaurantRepository, RestaurantRepository>();
    }
}