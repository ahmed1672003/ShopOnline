using Microsoft.EntityFrameworkCore;

using ShopOnline.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region Register Services

builder.Services.AddDbContext<ShopOnlineDbContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("ShopOnlineConnection")));
#endregion



builder.Services.AddControllers();
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
