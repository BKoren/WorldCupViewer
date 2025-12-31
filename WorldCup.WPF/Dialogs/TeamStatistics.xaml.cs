using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WorldCup.DataLayer.Models;

namespace WorldCup.WPF.Dialogs
{    
    public partial class TeamStatistics : Window
    {
        private readonly Team team;
        public TeamStatistics(Team team)
        {
            InitializeComponent();

            this.team = MainWindow.teams.Find(item => item.Country == team.Country);
            this.Opacity = 0;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            header.Height = this.ActualHeight * 0.2;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TeamName.Text = team.ToString();

            GamesPlayedText.Text = DataLayer.Resources.TextTeamGames;
            WinsText.Text = DataLayer.Resources.TextTeamWins;
            DrawsText.Text = DataLayer.Resources.TextTeamDraws;
            LossesText.Text = DataLayer.Resources.TextTeamLoss;
            GoalsScoredText.Text = DataLayer.Resources.TextTeamGoals;
            GoalsConcededText.Text = DataLayer.Resources.TextTeamConceded;
            GoalDifferenceText.Text = DataLayer.Resources.TextTeamDifference;

            GamesPlayedValue.Text = team.Games_played.ToString();
            WinsValue.Text = team.Wins.ToString();
            DrawsValue.Text = team.Draws.ToString();
            LossesValue.Text = team.Losses.ToString();
            GoalsScoredValue.Text = team.Goals_for.ToString();
            GoalsConcededValue.Text = team.Goals_against.ToString();
            GoalsDifferenceValue.Text = team.Goal_differential.ToString();

            this.BeginAnimation(
                Window.OpacityProperty,
                new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(1250))
            );
        }
    }
}
