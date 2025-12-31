using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Models;
using WorldCup.WPF.Images;

namespace WorldCup.WPF.Dialogs
{
    public partial class PlayerStatistics : Window
    {
        Player player;
        public PlayerStatistics(Player player)
        {
            InitializeComponent();
            
            this.player = player;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShirtNumberText.Text = DataLayer.Resources.TextMarkShirtNumber;
            PositionText.Text = DataLayer.Resources.TextMarkPosition;
            CaptainText.Text = DataLayer.Resources.TextMarkCapetain;
            GoalsText.Text = DataLayer.Resources.TextMarkGoals;
            CardsText.Text = DataLayer.Resources.TextMarkCards;

            PlayerImg.Source = ImgConverter.ToWPFImage(ImgHandeler.FindImg(player.Name, player.Shirt_Number));
            PlayerNameValue.Text = player.Name;
            ShirtNumberValue.Text = player.Shirt_Number.ToString();
            PositionValue.Text = player.Position;
            CapetainValue.Text = player.Captain.ToString();
            GoalsValue.Text = player.Goals.ToString();
            CardsValue.Text = player.Yellow_Cards.ToString();
        }
    }
}
