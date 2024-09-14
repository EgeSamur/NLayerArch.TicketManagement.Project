using NLayerArch.Project.Bussines;
using NLayerArch.Project.CrossCuttingConcerns.Exceptions;
using NLayerArch.Project.CrossCuttingConcerns;
using NLayerArch.Project.Security;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// AddDataLayerDPIs methodunu çaðýrýyoruz
builder.Services.AddDataLayerDPIs(builder.Configuration);
builder.Services.AddBussinesLayer();

//Katman Registrationlarý
builder.Services.AddCrossCuttingConcern();
builder.Services.AddSecurityServices();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Adisyon API", Version = "v1", Description = "Adisyon API" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Bearer yazýp boþluk býrak."
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
                {
                 Type = ReferenceType.SecurityScheme,
                 Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Exception Middleware ekliyoruz.
app.AddConfigureGlobalExceptionMiddleware();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
