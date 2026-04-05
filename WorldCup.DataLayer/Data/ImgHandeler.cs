using System;
using System.Drawing;
using System.IO;

namespace WorldCup.DataLayer.Data
{
    public static class ImgHandeler
    {       
        private readonly static string basePath = 
            Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\WorldCup.DataLayer\Resources\PlayersImages"
                )
            ); 

        private readonly static Image img = Resources.ImgDefault;

        public static Image Img
        {
            get => (Image)img.Clone();
        }

        public static Image FindImg(string player, int id)
        {
            string fullPath = Path.Combine(basePath, $"{player}_{id}.jpg");

            if (!File.Exists(fullPath))
                return Img;

            Image imgFileCopy = null;
            using (var fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            using (var originalImage = Image.FromStream(fileStream))
            {
                imgFileCopy = (Image)originalImage.Clone();
            }
            
            return imgFileCopy;
        }

        public static void SaveImg(string player, string id, Image fileName)
        {
            string fullPath = Path.Combine(basePath, $"{player}_{id}.jpg");

            try
            {
                string directory = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                try
                {
                    if (File.Exists(fullPath))
                        File.Delete(fullPath);
                }
                catch (IOException error)
                {
                    throw new Exception($"Faild to remove previus image.", error);
                }

                fileName.Save(fullPath);

                fileName?.Dispose();
                fileName = null;
            }
            catch (System.Runtime.InteropServices.ExternalException error)
            {
                throw new Exception("Faild to assign image to a player. Default image is assigend!", error);
            }
        }
    }
}
