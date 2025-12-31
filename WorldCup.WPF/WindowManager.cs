using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorldCup.DataLayer;
using WorldCup.WPF.Windows;

namespace WorldCup.WPF
{
    public class WindowManager
    {
        internal Size Size;

        internal bool IsFullScreen;

        internal bool Loading = true;

        public WindowManager()
        {
            SettingsManager.WPF = true;

            Base window;
            if (DataLayer.SettingsManager.CheckForSettings())
            {
                SetSize();

                window = new MainWindow(this);
            }

            else
                window = new Settings.StartUp(this);

            Next(window);
        }

        public void Next(Base window)
        {
            SetSize();
            if (IsFullScreen)
            {
                window.WindowState = WindowState.Maximized;
            }     

            else
            {                
                window.Width = Size.Width;
                window.Height = Size.Height;
            }

            window.BeforeShow();
        }

        public void Back()
        {
            
        }

        internal void SetSize()
        {
            switch(SettingsManager.Screen)
            {
                case "Small":
                    Size = new Size(520, 380);
                    IsFullScreen = false;
                break;

                case "Medium":
                    Size = new Size(720, 550);
                    IsFullScreen = false;
                break;

                case "Full":
                    IsFullScreen = true;
                break;

                default:
                    Size = new Size(520, 380);
                    IsFullScreen = false;
                break;
            }
        }

    }
}
