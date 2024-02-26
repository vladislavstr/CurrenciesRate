using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Hangfire
builder.Services.AddHangfire(x => x.UseSqlServerStorage(Environment.GetEnvironmentVariable("CurrencyDbConnect")));
builder.Services.AddHangfireServer();

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

app.UseHangfireDashboard("/hangfire");
RecurringJob.AddOrUpdate(() => Console.WriteLine("Test"), "35 11 * * *");

app.Run();
