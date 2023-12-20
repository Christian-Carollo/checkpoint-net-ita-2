using net_ita_2_checkpoint.Context;
using net_ita_2_checkpoint.Services;
using net_ita_2_checkpoint.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IDbContext, DbContext>();
builder.Services.AddTransient<ILoggingService, LoggingService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped < IReservationService, ReservationService>();
builder.Services.AddControllers();
builder.Services.AddMemoryCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
