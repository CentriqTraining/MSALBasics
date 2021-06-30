using ConsoleApp17.Properties;
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
        public static string[] Scopes = { "user.read" };
        public static string Redirect = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        public static string GetAuthToken()
        {
            IPublicClientApplication app= PublicClientApplicationBuilder
                    .Create(Settings.Default.ClientID)
                    .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
                    .WithAuthority(AzureCloudInstance.AzurePublic, Settings.Default.TenantID)
                    .Build();


            var token = app.AcquireTokenInteractive(Scopes).ExecuteAsync().GetAwaiter().GetResult();
            return token.AccessToken;
        }
    }
}
