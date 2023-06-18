using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcquireX.Wrap.AcquireXClientConfiguration
{
    public sealed partial class AcquireXClientConfigBuilder
    {
        private HttpClient client;
        private string clientId;
        private string clientSecret;
        private string grantType;
        private string scope;
        private AcquireXClientConfigBuilder config;

        public static Uri AuthBaseAddress => new Uri($"https://auth.dkhardware.com/");
        public static Uri BaseAddress => new Uri($"https://dkh-c-testing-api.staging.dkhdev.com/");

        public static string ClientId = "candidate1";
        public static string ClientSecret = "X01BvqCjkbFpsw5d1gAChjg1RrQc3c2q";
        public static string GrantType = "client_credentials";
        public static string Scope = "products";

        public AcquireXClientConfigBuilder()
        {
            client = new HttpClient();
            config = new AcquireXClientConfigBuilder(null, null);
        }

        public AcquireXClientConfigBuilder SetAuthorizationBaseAddress(Uri authBaseAddress)
        {
            client.BaseAddress = authBaseAddress ?? throw new ArgumentNullException(nameof(authBaseAddress));
            return this;
        }

        public AcquireXClientConfigBuilder SetClientBaseAddress(Uri baseAddress)
        {
            config = new AcquireXClientConfigBuilder(baseAddress, config.AccessToken);
            return this;
        }

        public AcquireXClientConfigBuilder SetGrantType(string grantType)
        {
            this.grantType = grantType ?? throw new ArgumentNullException(nameof(grantType));
            return this;
        }

        public AcquireXClientConfigBuilder SetClientId(string clientId)
        {
            this.clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            return this;
        }

        public AcquireXClientConfigBuilder SetClientSecret(string clientSecret)
        {
            this.clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            return this;
        }

        public AcquireXClientConfigBuilder SetScope(string scope)
        {
            this.scope = scope ?? throw new ArgumentNullException(nameof(scope));
            return this;
        }

        public async Task<AcquireXClientConfigBuilder> Build()
        {
            if (config.ClientBaseAddress is null)
            {
                throw new ArgumentNullException(nameof(config.ClientBaseAddress));
            }
            if (clientId is null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            if (clientSecret is null)
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }
            if (scope is null)
            {
                throw new ArgumentNullException(nameof(scope));
            }
            if (grantType is null)
            {
                throw new ArgumentNullException(nameof(grantType));
            }

            try
            {
                var content = new Dictionary<string, string>
            {
                {"grant_type", grantType},
                {"scope", scope},
                {"client_secret", clientSecret},
                {"client_id", clientId}
            };
                var formUrlEncodedContent = new FormUrlEncodedContent(content);
                var responseBody = await client.PostAsync("/realms/ctesting/protocol/openid-connect/token", formUrlEncodedContent);
                var responseString = await responseBody.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<OauthTokenResponse>(responseString);

                config = new AcquireXClientConfigBuilder(config.ClientBaseAddress, response.access_token);
                return config;
            }
            catch (HttpRequestException ex)
            {
                throw new OauthTokenException(ex.Message);
            }
        }
    }

}
