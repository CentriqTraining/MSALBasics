using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AzureAuthenticationStuff.GetAuthToken());
            var value = client.GetStringAsync(AzureAuthenticationStuff.Url)
                .GetAwaiter().GetResult();
            List<Employee> emps = JsonConvert.DeserializeObject<List<Employee>>(value);
            foreach (var item in emps)
            {
                Console.WriteLine(item.FirstName + ", " + item.LastName);
            }

        }

        private static void mycallback(LogLevel level, string message, bool containsPii)
        {
            Debug.WriteLine(message);
        }
    }
}
