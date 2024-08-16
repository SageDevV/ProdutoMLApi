using AllClassificationApi;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<AllClassificationModel.ModelInput, AllClassificationModel.ModelOutput>()
    .FromFile("Llms/AllClassificationModel.mlnet");

builder.Services.AddPredictionEnginePool<ProductClassification.ModelInput, ProductClassification.ModelOutput>()
    .FromFile("Llms/ProductClassification.mlnet");

builder.Services.AddPredictionEnginePool<ColorClassificationModel.ModelInput, ColorClassificationModel.ModelOutput>()
    .FromFile("Llms/ColorClassificationModel.mlnet");

builder.Services.AddPredictionEnginePool<ShapeClassificationModel.ModelInput, ShapeClassificationModel.ModelOutput>()
    .FromFile("Llms/ShapeClassificationModel.mlnet");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hava.Logistica.ProdutoMLApi",
        Version = "v1",
        Description = "ML.NET"
    });
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 52428800; 
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;  
});

app.MapControllers();
app.Run();
