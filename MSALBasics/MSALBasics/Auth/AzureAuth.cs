using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp13.Auth
{
    public class AzureAuth
    {
        public const string ClientId = "{enter Application (client) ID here}";
        public const string TenantId = "{Enter Tenant ID here}";

        public AzureAuth()
        {
            var results = Login().GetAwaiter().GetResult();
        }
        public async Task<AuthenticationResult> Login()
        {
            var app = PublicClientApplicationBuilder.Create(ClientId)
                .WithDefaultRedirectUri()
                .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                .Build();
            return await app.AcquireTokenInteractive(new string[] { "user.read" }).ExecuteAsync();
        }
    }
}