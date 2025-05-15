using LogSage.Api.Extensions;
using LogSage.Api.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogSage API", Version = "v1" });
    
    c.OperationFilter<FileUploadOperationFilter>();
    // Null referansları yok sayma
    c.SupportNonNullableReferenceTypes();
    
    // Swashbuckle.AspNetCore.Annotations kullanımını etkinleştir
    c.EnableAnnotations();
    
});
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80); // ✅ Bu varsa dışarıya açılır
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();