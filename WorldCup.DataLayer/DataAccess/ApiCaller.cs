using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Exceptions;
using WorldCup.DataLayer.Models;

namespace WorldCup.DataLayer.DataAccess
{
    internal class ApiCaller
    {
        private readonly string url;
        private readonly HttpClient client;       

        DataHandler handler;

        public ApiCaller() 
        {
            client = new HttpClient();

            switch (SettingsManager.Category)
            {
                case "M":
                    url = "https://worldcup-vua.nullbit.hr/men";

                break;

                case "F":
                    url = "https://worldcup-vua.nullbit.hr/women";

                break;
            }
        }

        internal async Task RequestAPI(DataLoader.Type option)
        {
            switch (option)
            {
                case DataLoader.Type.Team:
                    handler.Teams = await Request<List<Team>>
                        (string.Concat(url, "\\teams\\results"));
                break;

                case DataLoader.Type.Match:
                    handler.Matches = await Request<List<Match>>
                        (string.Concat(url, "\\matches"));
                break;
            }
        }

        private async Task<T> Request<T>(string url)
        {
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        return 
                            JsonSerializer.Deserialize<T>(
                                await response.Content.ReadAsStringAsync(),
                                new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true,
                                }
                            );
                    }
                    catch (Exception error)
                    {
                        throw new Exception("Downloaded data was in an invalid format!", error);
                    }
                }

                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        internal void SetObject(DataHandler handler) => this.handler = handler;

        public void Dispose()
        {
            client?.Dispose();

            handler = null;
        }
    }
}
