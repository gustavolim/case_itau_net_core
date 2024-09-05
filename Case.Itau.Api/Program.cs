using Case.Itau.Api.Configurations;
using Case.Itau.Api.Util.Health;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region [Configure Services]

builder.Services.AddControllers();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddDataBaseConfiguration(builder.Configuration);

builder.Services.AddAutoMapper();

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddHelthCheckConfiguration(builder.Configuration);

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
#endregion


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


#region [App Services]


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    LinqToDB.Data.DataConnection.TurnTraceSwitchOn();
    LinqToDB.Data.DataConnection.WriteTraceLine = (message, displayName, traceLevel) => { Console.WriteLine($"{message} {displayName}"); };
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseSwaggerSetup();

app.UseHealthCheck();
app.UseHealthCheckSetup();
app.Run();

#endregion



