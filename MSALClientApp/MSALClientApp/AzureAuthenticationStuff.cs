using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    public static class AzureAuthenticationStuff
    {
        public static string ClientID = "8ff723cc-e4fb-461b-a032-6a494da2141a";
        public static string TenantID = "1ee67c73-1eec-4dc1-9105-cbd0193a0915";
        public static string[] Scopes = { "https://centriqdata.azurewebsites.net/user_impersonation" };
        public static string Redirect = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        public static string Url = "https://centriqdata.azurewebsites.net/data/chuck";
        public static string GetAuthToken()
        {
            var app = PublicClientApplicationBuilder.Create(ClientID)
                .WithAuthority(AadAuthorityAudience.AzureAdMyOrg)
                .WithTenantId(TenantID)
                .WithRedirectUri(Redirect)
                .Build();

            var token = app.AcquireTokenInteractive(Scopes).ExecuteAsync().GetAwaiter().GetResult();
            return token.AccessToken;
        }
    }
}
