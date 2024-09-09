namespace Case.Itau.BFF.Services
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync();
    }

    public class TokenService : ITokenService
    {
        public Task<string> GetTokenAsync()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VySWQiLCJqdGkiOiJmNTUxN2JkOC04MDBjLTRjMTUtODM1NS00NmEzZmFmMGJhNTkiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZ3VzdGF2byIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InRlc3RlIiwiZXhwIjoxNzI1ODE5NTg1LCJpc3MiOiJpdGF1LXRlc3RlIiwiYXVkIjoiaXRhdS10ZXN0ZSJ9.zGUXu5QLAaBanNPk9F_zapdmW4Wi76VCrTeFXMd2xc4"; 
            return Task.FromResult(token);
        }
    }
}
