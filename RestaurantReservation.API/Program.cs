using RestaurantReservation.Db;
using RestaurantReservation.Profiles;
using RestaurantReservation.Repositories.RestaurantRepositories;
using RestaurantReservation.Services.RestaurantServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<RestaurantReservationDbContext>();
builder.Services.AddTransient<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddAutoMapper(typeof(RestaurantProfile));
builder.Services.AddTransient<IRestaurantService, RestaurantService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();