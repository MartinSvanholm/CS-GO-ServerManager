using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HVKClassLibary.Models;
using System.Diagnostics;
using HVKClassLibary.Models.DTO_s.Server_DTO;

namespace HVKClassLibary.Shared
{
    public static class ServerProcessor
    {
        public static async Task<string> CheckServerStatus(string id)
        {
            string url = ApiHelper.ApiClient.BaseAddress + $"/api/0.1/game-servers/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ServerDTO>();

                    if (result.booting)
                        return "Booting";
                    else if (result.on)
                        return "Online";
                    else
                        return "Offline";
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Server>> LoadServers()
        {
            string url = ApiHelper.ApiClient.BaseAddress + "/api/0.1/game-servers";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        List<ServerDTO> servers = new();
                        List<Server> _servers = new();

                        servers = await response.Content.ReadAsAsync<List<ServerDTO>>();

                        foreach (ServerDTO serverDTO in servers)
                        {
                            _servers.Add(new Server(
                                serverDTO.id, 
                                serverDTO.name, 
                                $"connect {serverDTO.ip}", 
                                serverDTO.players_online, 
                                ServerStatusConverter(serverDTO)
                            ));
                        }
                        return _servers;
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine("");
                        Trace.WriteLine(e.Message);
                        Trace.WriteLine("");
                    }
                    return null;
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
        }

        public static async Task ServerAction(string id, string parameter)
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

        private static string ServerStatusConverter(ServerDTO serverDTO)
        {
            if (serverDTO.booting == true)
                return "Booting";
            else if (serverDTO.on == true)
                return "Online";
            else
                return "Offline";
        }
    }
}
