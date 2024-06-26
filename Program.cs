using socialmediaproject.Models.Data;
using socialmediaproject.Repo.Interfaces;
using socialmediaproject.Repo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<DataDbContext>();
builder.Services.AddTransient<IRegistrationRepo, RegistrationRepo>();
builder.Services.AddTransient<IPostRepo, PostRepo>();
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
