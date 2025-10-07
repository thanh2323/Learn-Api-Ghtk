using ClientAuthentication;

namespace Ghtk.Api.AuthenticationHandler
{
    public class RemoteClientSourceAuthenticationHandler : IClientSourceAuthenticationHandler
    {
        private readonly string authenticationServiceUrl;
        private static HttpClient httpClient = new HttpClient();

        public RemoteClientSourceAuthenticationHandler(string authenticationServiceUrl)
        {
            this.authenticationServiceUrl = authenticationServiceUrl;
        }
        public bool Validate(string clientSource)
        {
            if (string.IsNullOrEmpty(clientSource))
            {
                return false;
            }
            var reponse = httpClient.GetAsync($"{authenticationServiceUrl}/api/ClientSource/{clientSource}").Result;
            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
