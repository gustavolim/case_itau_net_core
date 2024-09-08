using Case.Itau.Api.Configurations;
using Case.Itau.Api.Middlewares;
using Case.Itau.Business.Util.Health;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region [Configure Services]

builder.Services.AddControllersConfiguration();

builder.Services.AddAuthenticationJwt();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddDataBaseConfiguration(builder.Configuration);

builder.Services.AddAutoMapper();

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddHelthCheckConfiguration(builder.Configuration);

builder.Services.Addhsts();

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

// Adicionando configuração CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Permite o domínio do Angular
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    LinqToDB.Data.DataConnection.TurnTraceSwitchOn();
    LinqToDB.Data.DataConnection.WriteTraceLine = (message, displayName, traceLevel) => { Console.WriteLine($"{message} {displayName}"); };
}

// Middleware de validação deve estar antes de UseRouting()
app.UseMiddleware<ValidationMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

// Use o middleware de CORS
app.UseCors("AllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerSetup();

app.UseHealthCheck();
app.UseHealthCheckSetup();

app.Run();
