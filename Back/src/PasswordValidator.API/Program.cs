using PasswordValidator.Infrastructure.Configuration;
using PasswordValidator.Infrastructure.Factories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RegexRule>(builder.Configuration.GetSection("RegexRule"));
builder.Services.Configure<RetryRules>(builder.Configuration.GetSection("RetryRules"));
builder.Services.AddSingleton<IPasswordServiceFactory, PasswordServiceFactory>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup Microsoft Extensions Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();   

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Logger.LogInformation("App started...");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.Logger.LogWarning("To Do: Configure at least one specific origin");

app.MapControllers();

app.Run();
