using DAL.Repositories;
using DAL.Services;
using DemoAPI_Complete.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddScoped<IGameRepository, GameService>(sp => 
    new GameService(
        new System.Data.SqlClient.SqlConnection(
            builder.Configuration.GetConnectionString("default"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
 
app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<ChatHub>("chathub");
app.MapControllers();

app.Run();
