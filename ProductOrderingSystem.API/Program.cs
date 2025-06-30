using Microsoft.AspNetCore.RateLimiting;
using ProductOrderingSystem.Application.Interfaces;
using ProductOrderingSystem.Application.Services;
using ProductOrderingSystem.Infrastructure.FakeStoreClient;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductIntegrationService,ProductIntegrationService>();
builder.Services.AddHttpClient<FakeStoreClient>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 5; // 5 istek
        options.Window = TimeSpan.FromSeconds(10); // her 10 saniyede
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRateLimiter();

//app.UseAuthorization();
app.MapControllers().RequireRateLimiting("fixed");
app.UseCors("AllowAll");

app.Run();