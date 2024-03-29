
using CentricaStoresApi.BudsinessLogic;
using CentricaStoresApi.Data;
using DataAccess.DbAccess;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();


builder.Services.AddTransient<CentricaDbContext>();
builder.Services.AddSingleton<IResultChecker, ResultChecker>();
builder.Services.AddSingleton<IDistrictsRepo, DistrictsRepo>();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
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
