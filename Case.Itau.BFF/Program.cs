using Refit;
using Serilog;
using AutoMapper;
using Case.Itau.BFF.Services;
using Case.Itau.BFF.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));


// Adicionar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Registre o TokenService
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IFundoService, FundoService>();

// Registre o DelegatingHandler
builder.Services.AddTransient<AuthenticatedHttpClientHandler>();

// Configure o Refit para usar o AuthenticatedHttpClientHandler
builder.Services.AddRefitClient<IFundoApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7187"))
    .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();
// Configurar os serviços

// Adicionar controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
