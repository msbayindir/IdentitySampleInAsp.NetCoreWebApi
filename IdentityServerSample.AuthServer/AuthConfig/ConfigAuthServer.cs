using IdentityServer4.Models;

namespace IdentityServerSample.AuthServer.AuthConfig;

public static class ConfigAuthServer
{

    public static IEnumerable<ApiScope> GetScope() =>
        new List<ApiScope>()
        {
            new ApiScope("Api1.Write", "Api1 Yazma Izini"),
            new ApiScope("Api1.Read", "Api1 Okuma Izini"),
            new ApiScope("Api2.Write", "Api2 Yazma Izini"),
            new ApiScope("Api2.Read", "Api2 Okuma Izini"),
        };

    public static IEnumerable<ApiResource> GetApiResource() =>
        new List<ApiResource>()
        {
            new ApiResource("Api1") { Scopes = { "Api1.Write", "Api1.Read" } },
            new ApiResource("Api2") { Scopes = { "Api2.Write", "Api2.Read" } },

        };
    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "Client1",
                ClientName = "Client1",
                ClientSecrets = { new Secret("client1".Sha256()) },
                AllowedGrantTypes = { GrantType.ClientCredentials },
                AllowedScopes = { "Api1.Read" }
            },
            new Client
            {
                ClientId = "Client2",
                ClientName = "Client2",
                ClientSecrets = { new Secret("client2".Sha256()) },
                AllowedGrantTypes = { GrantType.ClientCredentials },
                AllowedScopes = { "Api2.Write", "Api2.Read" }
            },
          
        };
    }
}