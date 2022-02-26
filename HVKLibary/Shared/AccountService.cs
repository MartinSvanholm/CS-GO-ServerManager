using HVKClassLibary.Models.Account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKClassLibary.Shared
{
    public static class AccountService
    {
        public static bool IsLoggedIn { get; set; }

        public static Account Account { get; set; }

        public static async Task Login(Account account)
        {
            ApiHelper.Email = account.Email;
            ApiHelper.Password = account.Password;

            ApiHelper.InitializeClient();

            string url = ApiHelper.ApiClient.BaseAddress + $"/api/0.1/account";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine($"Login succesfull");
                    Account = account;
                }
                else
                {
                    ApiHelper.Email = "";
                    ApiHelper.Password = "";

                    ApiHelper.InitializeClient();

                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
        }
    }
}
