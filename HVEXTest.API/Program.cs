using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Services;
using HVEXText.Data.Config;
using HVEXText.Data.Repositories;
using HVEXText.Data.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<HvexTesteDatabaseSettings>(
    builder.Configuration.GetSection("HvexTesteDatabase"));


builder.Services.AddTransient<ITransformerRepository, TransformerRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITestRepository, TestRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();


builder.Services.AddTransient<ITransformerService, TransformerService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITestService, TestService>();
builder.Services.AddTransient<IReportService, ReportService>();

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
