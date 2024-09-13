using NLayerArch.Project.Bussines;
using NLayerArch.Project.CrossCuttingConcerns.Exceptions;
using NLayerArch.Project.CrossCuttingConcerns;
using NLayerArch.Project.Security;
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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Exception Middleware ekliyoruz.
app.AddConfigureGlobalExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
