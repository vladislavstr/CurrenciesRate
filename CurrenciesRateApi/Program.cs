using Hangfire;
using CurrenciesRateBll;
using CurrenciesRateDal;
using UsersGroupApi;
using UsersGroupBll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Hangfire
builder.Services.AddHangfire(x => x.UseSqlServerStorage(Environment.GetEnvironmentVariable("CurrencyHangfireDbConnect")));
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddAutoMapper(typeof(MapperApiCurrencyProfile), typeof(MapperBllCurrencyProfile));
builder.Services.AddSingleton<CurrencyContext>();

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

app.UseHangfireDashboard("/hangfire");
RecurringJob.AddOrUpdate<ICurrencyService>(x => x.LoadDataOfCurrenciesAsync(), "35 11 * * *");

app.Run();
