using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Shared
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static string Email { get; set; }
        public static string Password { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.BaseAddress = new Uri("https://dathost.net");
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String( Encoding.ASCII.GetBytes ( $"{Email}:{Password}" )));

            Trace.WriteLine($" -- Created authorization header - {ApiClient.DefaultRequestHeaders.Authorization.Scheme} -- ");
            Trace.WriteLine($"Email: {Email}, Passsword: {Password}");
            Trace.WriteLine(" -- Api initialized -- ");
        }
    }
}