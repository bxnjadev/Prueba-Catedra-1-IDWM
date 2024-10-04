using Microsoft.EntityFrameworkCore;
using P_Cat_1_IDWM.data;
using P_Cat_1_IDWM.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=app.db";

builder.Services.AddDbContext<DataProvider>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope()) {
 var services = scope.ServiceProvider;
    var dataProvider = services.GetRequiredService<DataProvider>();
    DataSeeder.Seed(dataProvider);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
