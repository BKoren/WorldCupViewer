using System;
using System.Threading.Tasks;
using WorldCup.DataLayer.DataAccess;
using WorldCup.DataLayer.Exceptions;

namespace WorldCup.DataLayer.Data
{
    public class DataLoader : IDisposable
    {
        public enum Type
        {
            Team,
            Match
        }

        private readonly Type option;

        private ApiCaller apiCaller;          
        private JsonReader jsonReader;

        public DataLoader(DataHandler handler, Type option)
        {
            this.option = option;

            apiCaller = new ApiCaller();
            apiCaller.SetObject(handler);

            jsonReader = new JsonReader();
            jsonReader.SetObject(handler);
        }

        public async Task UploadData()
        {
            switch (SettingsManager.LoadMethod)
            {
                case "API":
                    await API_Method();

                break;

                case "JSON":
                    await JSON_Method();

                break;

                default:
                    await API_Method();

                break;
            }

        }

        private async Task JSON_Method()
        {
            try
            {              
                await jsonReader.RequestJSON(option);
            }
            catch (Exception error)
            {
                throw new DataAccessException(
                    description: "Error occured while trying to upload data.",
                    solution: "Try switching uploading method to online.",
                    action: "Forwarding to the settings form.",
                    innerException: error
                );
            }
        }

        private async Task API_Method()
        {
            try
            {
                await apiCaller.RequestAPI(option);
            }
            catch (Exception error)
            {
                throw new DataAccessException(
                    description: "Error occured while trying to download data.",
                    solution: "Try switching uploading method to offline.",
                    action: "Forwarding to the settings form.",
                    innerException: error
                );
            }   
        }

        public void Dispose()
        {
            apiCaller?.Dispose();

            apiCaller = null;
            jsonReader = null;

        }
    }
}
