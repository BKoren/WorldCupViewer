using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WorldCup.DataLayer.Models;

namespace WorldCup.WPF.Controls
{
    public partial class MatchControl : UserControl
    {
        internal Match match;

        internal bool isClicked = false;

        internal static List<MatchControl> matches = new List<MatchControl>();

        public MatchControl(Match match)
        {
            InitializeComponent();     
            
            this.match = match;

            matches.Add(this);
        }
        public void Control_Loaded(object sender, RoutedEventArgs e)
        {
            homeTeam.Text = match.Home_team.Country;
            awayTeam.Text = match.Away_team.Country;
            
            score.Text = $"{match.Home_team.Goals} : {match.Away_team.Goals}";
        }
        private void Control_SizeChanged(object sender, SizeChangedEventArgs e)
        {                                    
            Resources["fontSize"] = (this.ActualHeight + this.ActualWidth) * 0.02;
        }
        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (MatchControl match in matches)
            {
                if (match.isClicked)
                    match.SimulateCLick();
            }

            SimulateCLick();
        }

        private void SimulateCLick()
        {
            isClicked = !isClicked;            

            switch (isClicked)
            {
                case true:
                    this.Background = new SolidColorBrush(Colors.LightGray);
                break;

                case false:
                    this.Background = new SolidColorBrush(Colors.White);
                break;                       
            }
        }
    }
}
