using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Models;
using WorldCup.WPF.Dialogs;
using WorldCup.WPF.Images;
using WorldCup.WPF.Windows;

namespace WorldCup.WPF.Controls
{
    public partial class PlayerControl : UserControl
    {
        private Player player;
        public PlayerControl(Player player)
        {
            InitializeComponent();

            this.player = player;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {                        
            PlayerImg.Source = ImgConverter.ToWPFImage(ImgHandeler.FindImg(player.Name, player.Shirt_Number));
            StarImg.Source = ImgConverter.ToWPFImage(DataLayer.Resources.ImgStar, true);

            PlayerNameValue.Text = player.Name.Contains(" ") ? player.Name : $"     {player.Name}     ";
            PlayerShirtNumberValue.Text = player.Shirt_Number.ToString();
            PlayerShirtNumberText.Text = DataLayer.Resources.TextMarkShirtNumber;

            if(player.Is_Favorite)            
                StarImg.Visibility = Visibility.Visible;

            else            
                StarImg.Visibility = Visibility.Collapsed;                        
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PlayerImg.Height = this.ActualHeight * 0.5;

            StarImg.Height = this.ActualHeight * 0.175;
            StarImg.Width = this.ActualWidth * 0.175;

            Resources["FontSize"] = this.ActualHeight * 0.05;
        }

        private void UserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerStatistics playerStatistics = new PlayerStatistics(player);

            playerStatistics.ShowDialog();
        }
    }
}
