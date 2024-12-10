using Microsoft.EntityFrameworkCore;
using ProductionHostingService.Repository;
using ProductionHostingService.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Подключаем Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Подключение к БД
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация репозиториев и Unit of Work
builder.Services.AddScoped<IEquipmentContractRepository, EquipmentContractRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Регистрация сервисов
builder.Services.AddScoped<ContractsService>();

// Подключаем контроллеры
builder.Services.AddControllers();

//Додаємо перевірку ключа у сваггер
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("api-key", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "api-key",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Description = "API Key needed to access the endpoints. X-Api-Key: {your key}"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
    {
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
            Name = "api-key",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                Id = "api-key"
            },
        },
        new string[] {}
    }});
});

var app = builder.Build();

// Додаємо Swagger UI в режимі Дев
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Додаємо middleware для перевірки API ключа
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

// Привязываем контроллеры
app.MapControllers();

app.Run();

