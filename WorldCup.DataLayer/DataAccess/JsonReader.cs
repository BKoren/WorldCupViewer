using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Models;

namespace WorldCup.DataLayer.DataAccess
{
    internal class JsonReader
    {
        private readonly string path = 
            Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\WorldCup.DataLayer\Resources\Data"
                )
            );

        DataHandler handler;

        public JsonReader() 
        {
            switch (SettingsManager.Category)
            {
                case "M":
                    path += "\\Men";

                break;

                case "F":
                    path += "\\Woman";

                break;
            }
        }
        internal async Task RequestJSON(DataLoader.Type option)
        {
            switch (option)
            {
                case DataLoader.Type.Team:
                    handler.Teams = await Request<List<Team>>
                        (string.Concat(path, "\\results.json"));
                break;

                case DataLoader.Type.Match:
                    handler.Matches = await Request<List<Match>>
                        (string.Concat(path, "\\matches.json"));
                break;
            }
        }

        private async Task<T> Request<T>(string path) 
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            return
                await Task.Run(() =>
                {               
                    return
                        JsonSerializer.Deserialize<T>(
                            File.ReadAllText(path),
                            new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true,
                            }   
                        );
                });
        }

        internal void SetObject(DataHandler handler) 
            => this.handler = handler;

        public void Dispose() 
            => handler = null;        
    }
}
