using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace TTech.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles" , "your role(s)" , new[] {"role"}),
            new IdentityResource("country" , "They country user lives in", new List<string>{"country"})
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("imagegalleryapi" , "Image Gallery API" , new[] {"role" , "country"})
            {
                Scopes = { "imagegalleryapi.fullacess" , "imagegalleryapi.write" , "imagegalleryapi.read" },
                ApiSecrets = { new Secret("apisecret".ToSha256()) },
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("imagegalleryapi.fullacess"),
                new ApiScope("imagegalleryapi.write"),
                new ApiScope("imagegalleryapi.read"),
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new Client
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Reference,
                    RedirectUris =
                    {
                        "https://localhost:7184/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7184/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "imagegalleryapi.read",
                        "imagegalleryapi.write",
                        "country"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //RequireConsent = true,
                    AccessTokenLifetime = 120,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                }, 
                new Client
                {
                    ClientName = "Image Gallery BFF",
                    ClientId = "imagegallerybff",
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Reference,
                    RedirectUris =
                    {
                        "https://localhost:7164/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7164/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "imagegalleryapi.read",
                        "imagegalleryapi.write",
                        "country"
                    },
                    ClientSecrets =
                    {
                        new Secret("bffsecret".Sha256())
                    },
                    //RequireConsent = true,
                    AccessTokenLifetime = 120,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                }, 

            };
}