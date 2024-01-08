using FirmaSiparisYonetimDataLayer.Context;
using FirmaSiparisYonetimDataLayer.UOW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient((s) => UnitOfWork.Create());

using (SiparisYonetimDBContext db = new SiparisYonetimDBContext())
{
    db.Database.Migrate();
}

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
