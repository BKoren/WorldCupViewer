using System;
using System.Collections.Generic;
using System.Windows;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Models;


namespace WorldCup.WPF.Windows
{
    public partial class TeamSelection : Base
    {                
        public TeamSelection(WindowManager manager) : base(manager)
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.title.Text = DataLayer.Resources.BtnSetTeam;
            this.btnApply.Content = DataLayer.Resources.BtnApply;
            this.btnBack.Content = DataLayer.Resources.BtnBack;
        }

        private void DisplayTeams()
        {
            List<Team> teams = new List<Team>(MainWindow.teams);

            teams.Sort();
            foreach (Team team in teams)
                teamSelector.Items.Add(team);

            if (SettingsManager.TeamFavorite is null)
                teamSelector.SelectedIndex = 0;            

            else
            {
                for (int i = 0; i < teamSelector.Items.Count; i++)
                {
                    if (teamSelector.Items[i].ToString() == SettingsManager.TeamFavorite.ToString())
                        teamSelector.SelectedIndex = i;
                }
            }
        }

        public override void BeforeShow()
        {
            DisplayTeams();

            base.BeforeShow();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            header.Height = this.ActualHeight * 0.15;

            teamSelector.Width = this.ActualWidth * 0.6;
            teamSelector.Height = this.ActualHeight * 0.075;

            footer.Height = this.ActualHeight * 0.1;
            footer.Width = this.ActualWidth * 0.8;

            btnBack.Height = this.ActualHeight * 0.1;
            btnBack.Width = this.ActualWidth * 0.125;

            btnApply.Height = this.ActualHeight * 0.1;
            btnApply.Width = this.ActualWidth * 0.125;

            Resources["fontSize"] = Math.Min(this.ActualHeight, this.ActualWidth) * 0.035;
        }

        private Object selectedTeam;
        private void TeamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeam = teamSelector.Items[teamSelector.SelectedIndex];
        }
        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= Window_Closing;

            SettingsManager.TeamFavorite = selectedTeam;

            _manager.Loading = true;
            _manager.Next(new MainWindow(_manager));

            Close();      
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= Window_Closing;
            _manager.Next(new MainWindow(_manager));

            Close();
        }
    }
}
