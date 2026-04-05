using System.Drawing.Imaging;
using System.IO;

using System.Windows.Media.Imaging;

namespace WorldCup.WPF.Images
{
    internal class ImgConverter
    {
        public static BitmapImage ToWPFImage(System.Drawing.Image image, bool png = false)
        {
            MemoryStream stream = new MemoryStream();      

            image.Save(stream, png ? ImageFormat.Png : ImageFormat.Jpeg);
            stream.Position = 0;

            BitmapImage result = new BitmapImage();
            result.BeginInit();
            result.StreamSource = stream;
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.EndInit();
            result.Freeze();

            return result;
        }
    }
}
