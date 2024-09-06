using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Case.Itau.Api.Configurations
{
    public static class SecurityConfig
    {
        public static void AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddMvcOptions(opt =>
                {
                    opt.InputFormatters.RemoveType<XmlSerializerInputFormatter>();
                    opt.OutputFormatters.RemoveType<XmlSerializerOutputFormatter>();

                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                    opt.Filters.Add(new AuthorizeFilter(policy));
                });
        }

        public static void AddAuthenticationJwt(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    // Configurações do Issuer e Audience
                    ValidIssuer = "itau-teste",  // Configure o issuer que você usa para gerar o token
                    ValidAudience = "itau-teste",  // Configure o audience que você usa para gerar o token

                    // Chave de assinatura usada para validar o token
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("teste-itau-fundos-investimento-secure-long-secret-key")),

                    // Tempo de vida do token
                    ClockSkew = TimeSpan.FromDays(365)
                };
            });
        }

        public  static void Addhsts(this IServiceCollection services)
        {
            services.AddHsts(opt =>
            {
                opt.Preload = true;
                opt.IncludeSubDomains = true;
                opt.MaxAge = TimeSpan.FromDays(365);
            });
        }
    }
}
