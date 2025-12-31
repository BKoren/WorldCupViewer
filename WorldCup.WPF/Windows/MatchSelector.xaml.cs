using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Models;
using WorldCup.WPF.Controls;

namespace WorldCup.WPF.Windows
{    
    public partial class MatchSelector : Base
    {        
        public MatchSelector(WindowManager manager) : base(manager)
        {
            InitializeComponent();            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.title.Text = DataLayer.Resources.BtnSetMatch;
            this.btnApply.Content = DataLayer.Resources.BtnApply;
            this.btnBack.Content = DataLayer.Resources.BtnBack;
            
            this.MinHeight = Math.Sqrt((Double)MatchesPanel.Children.Count) * 130D;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            header.Height = Math.Min(this.ActualWidth, this.ActualHeight) * 0.125;            
            
            content.Width = this.ActualWidth * 0.65;

            footer.Height = this.ActualHeight * 0.1;
            footer.Width = this.ActualWidth * 0.8;

            btnBack.Height = this.ActualHeight * 0.1;
            btnBack.Width = this.ActualWidth * 0.125;            

            btnApply.Height = this.ActualHeight * 0.1;
            btnApply.Width = this.ActualWidth * 0.125;

            Resources["fontSize"] = Math.Min(this.ActualHeight, this.ActualWidth) * 0.02;

            foreach (MatchControl match in MatchesPanel.Children)
            {
                match.Height = this.ActualHeight * 0.085;             
            }
        }

        private void LoadOperation()
        {
            List<Match> matches = new List<Match>(MainWindow.matches);

            MatchControl.matches.Clear();
            foreach (Match match in matches)
            {
                MatchesPanel.Children.Add(new MatchControl(match));                
            }
        }

        public override void BeforeShow()
        {
            LoadOperation();

            base.BeforeShow();
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            MatchControl favorite = MatchControl.matches.Find(match => match.isClicked);

            if (favorite != null)
            {
                Match result = favorite.match;

                SettingsManager.MatchFavorite = result;

                this.Closing -= Window_Closing;

                _manager.Loading = true;
                _manager.Next(new MainWindow(_manager));

                Close();
            }

            else
            {
                MessageBox.Show($"No favorite match selected!");
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= Window_Closing;
            _manager.Next(new MainWindow(_manager));

            Close();
        }
    }
}
