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
        public static string ClientID = "d824b26a-e490-4990-aa45-1add6c11f80f";
        public static string TenantID = "1ee67c73-1eec-4dc1-9105-cbd0193a0915";
        public static string[] Scopes = { "user.read", "api://d824b26a-e490-4990-aa45-1add6c11f80f/user_impersonation" };
        public static string Redirect = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        public static string Url = "https://centriqtoons.azurewebsites.net/toons";
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
