using Case.Itau.BFF.Services;
using System.Net.Http.Headers;

namespace Case.Itau.BFF.Configurations
{
    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly ITokenService _tokenService;

        public AuthenticatedHttpClientHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Obtenha o token do serviço de autenticação
            var token = await _tokenService.GetTokenAsync();

            // Adicione o token ao cabeçalho Authorization
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }

}
