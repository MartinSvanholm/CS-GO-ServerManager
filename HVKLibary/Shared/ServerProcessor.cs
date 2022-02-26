using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HVKClassLibary.Models;
using System.Diagnostics;

namespace HVKClassLibary.Shared
{
    public static class ServerProcessor
    {
        public static async Task<List<Server>> LoadServers()
        {
            string url = ApiHelper.ApiClient.BaseAddress + "/api/0.1/game-servers";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Server> servers = await response.Content.ReadAsAsync<List<Server>>();

                    //Trace.WriteLine("");
                    //foreach (Server server in servers)
                    //{
                    //    Trace.WriteLine(server.Name);
                    //}
                    //Trace.WriteLine("");
                    return servers;
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
        }

        public static async Task ServerSpecificAction(string id, string parameter)
        {
            string url = ApiHelper.ApiClient.BaseAddress + $"/api/0.1/game-servers/{id}/{parameter}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, null))
            {
                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine($"Server {id} {parameter}");
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
        }

        public static async Task SendCommand(string id, string command)
        {
            string url = ApiHelper.ApiClient.BaseAddress + $"/api/0.1/game-servers/{id}/console";

            var values = new Dictionary<string, string>
            {
                { "line", command },
            };
            var content = new FormUrlEncodedContent(values);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine($"Command {command} executed on {id}");
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
        }
    }
}
