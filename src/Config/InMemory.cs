using System;
using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Demo.IdentityServer.Config
{
    public class InMemory
    {
        private static String ApiScopeName = "api";

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "th",
                    Password = "th"
                },

                new TestUser
                {
                    SubjectId = "2",
                    Username = "mr",
                    Password = "mr"
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource(ApiScopeName, "API");
        }

        public static IEnumerable<Client> GetClients()
        {
            yield return new Client
            {
                AccessTokenType = AccessTokenType.Jwt,
                Enabled = true,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientId = "ro",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = {ApiScopeName}
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }
    }
}
