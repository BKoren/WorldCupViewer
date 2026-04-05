using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Models;
using WorldCup.WPF.Controls;
using WorldCup.WPF.Dialogs;

namespace WorldCup.WPF.Windows
{    
    public partial class MatchStatistics : Base
    {
        private readonly Match match;        
        public MatchStatistics(WindowManager manager) : base(manager)
        {
            InitializeComponent();

            this.match = SettingsManager.MatchFavorite;            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnHomeStatistics.Content = DataLayer.Resources.BtnTeamStatistics;            
            btnAwayStatistics.Content = DataLayer.Resources.BtnTeamStatistics;
            btnBack.Content = DataLayer.Resources.BtnBack;

            labelHomeTeamText.Text = match.Home_team.ToString().Length < match.Away_team.ToString().Length 
                ? match.Home_team.ToString() + 
                    AppendSpace(match.Away_team.ToString().Length - match.Home_team.ToString().Length)
                : match.Home_team.ToString();

            labelAwayTeamText.Text = match.Away_team.ToString().Length < match.Home_team.ToString().Length
                ? match.Away_team.ToString() +
                    AppendSpace(match.Home_team.ToString().Length - match.Away_team.ToString().Length)
                : match.Away_team.ToString();
            
            labelMatchScoreText.Text = $"{match.Home_team.Goals} : {match.Away_team.Goals}";
        }
        private string AppendSpace(int length)
        {
            string result = string.Empty;
            for(int i = 0; i < length; i++) 
                result += " ";

            return result;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            header.Height = new GridLength(this.ActualHeight * 0.125);

            labelMatchScore.Width = this.ActualWidth * 0.1;

            const double btnElementHeight = 0.1;
            const double btnElementWidth = 0.075;

            btnHomeStatisticsLayout.Width = this.ActualWidth * btnElementHeight;
            btnHomeStatisticsLayout.Height = this.ActualHeight * btnElementWidth;

            btnAwayStatisticsLayout.Width = this.ActualWidth * btnElementHeight;
            btnAwayStatisticsLayout.Height = this.ActualHeight * btnElementWidth;

            Resources["btnBackFontSize"] = Math.Min(this.ActualHeight, this.ActualWidth) * 0.025;
            Resources["btnStatisticsFontSize"] = Math.Min(this.ActualHeight, this.ActualWidth) * 0.025;
        }

        public override void BeforeShow()
        {
            Loading loading = new Loading();
            loading.Show();

            LoadOperation();

            loading.Close();

            _manager.Loading = false;

            base.BeforeShow();
        }

        private List<Player> players;
        private Dictionary<string, int> formation;
        private void LoadOperation()
        {           
            SettingsManager.LoadFavoritePlayers();

            players = new List<Player>(match.Home_team_statistics.Starting_eleven);            
            AddMissingInformation(players, match.Home_team_events);

            formation = new Dictionary<string, int>(ReadFormation(match.Home_team_statistics.Tactics));

            ResetIndexes();
            AddControls("Home_Team");

            players = new List<Player>(match.Away_team_statistics.Starting_eleven);
            AddMissingInformation(players, match.Away_team_events);

            formation = new Dictionary<string, int>(ReadFormation(match.Away_team_statistics.Tactics));

            ResetIndexes();
            AddControls("Away_Team");            
        }

        private void AddMissingInformation(List<Player> players, List<Event> events)
        {
            
            foreach(Player player in players)
            {
                player.Goals = 0;
                player.Yellow_Cards = 0;

                if(SettingsManager.PlayersFavorite.Contains(player))
                    player.Is_Favorite = true;
                else
                    player.Is_Favorite = false;

                foreach(Event e in events)
                {
                    if(e.Player == player.Name)
                    {
                        if (e.Type_of_event == "goal" || e.Type_of_event == "goal-penalty")
                            player.Goals++;

                        else if(e.Type_of_event == "yellow-card")
                            player.Yellow_Cards++;
                    }
                }
            }
        }

        private Grid element;
        private string team;
        private void AddControls(string team)
        {
            this.team = team;   

            foreach (Player player in players)
            {
                if(player.Position == "Goalie")
                {
                    element = (team == "Home_Team") 
                        ? LeftGoalkeeper 
                        : RightGoalkeeper;

                    PlayerControl control = new PlayerControl(player);
                    control.Style = (Style)this.FindResource("PlayerControlsAnimation");
                    
                    element.Children.Add(control);
                }

                if(player.Position == "Defender")
                {
                    if (formation["Defense"] > 0)                    
                        AddToDefense(player);
                    
                    else
                        AddToMidfilder1(player);                                                         
                }

                if(player.Position == "Midfield")
                {
                    if (formation["Midfilder1"] > 0)
                        AddToMidfilder1(player);

                    else if (formation.ContainsKey("Midfilder2") && formation["Midfilder2"] > 0)
                        AddToMidfilder2(player);

                    else if (formation["Defense"] > 0)
                        AddToDefense(player);

                    else
                        AddToAttack(player);
                }

                if(player.Position == "Forward")
                {
                    if (formation["Attack"] > 0)
                        AddToAttack(player);

                    else if (formation.ContainsKey("Midfilder2") && formation["Midfilder2"] > 0)
                        AddToMidfilder2(player);

                    else
                        AddToMidfilder1(player);
                }
            }            
        }

        private int AttckIndex = 0;
        private void AddToAttack(Player player)
        {
            PlayerControl control = new PlayerControl(player);
            control.Style = (Style)this.FindResource("PlayerControlsAnimation");

            element = (team == "Home_Team") 
                ? LeftAttack : RightAttack;

            Grid.SetRow(control, AttckIndex);
            AttckIndex++;

            element.RowDefinitions.Add(new RowDefinition());
            element.Children.Add(control);

            formation["Attack"]--;
        }

        private int Midfilder2Index = 0;
        private void AddToMidfilder2(Player player)
        {
            PlayerControl control = new PlayerControl(player);
            control.Style = (Style)this.FindResource("PlayerControlsAnimation");

            element = (team == "Home_Team")
                ? LeftMidfilder2 : RightMidfilder2;

            Grid.SetRow(control, Midfilder2Index);
            Midfilder2Index++;

            element.RowDefinitions.Add(new RowDefinition());
            element.Children.Add(control);

            formation["Midfilder2"]--;
        }

        private int Midfilder1Index = 0;
        private void AddToMidfilder1(Player player)
        {
            PlayerControl control = new PlayerControl(player);
            control.Style = (Style)this.FindResource("PlayerControlsAnimation");

            element = (team == "Home_Team")
               ? LeftMidfilder1 : RightMidfilder1;

            Grid.SetRow(control, Midfilder1Index);
            Midfilder1Index++;

            element.RowDefinitions.Add(new RowDefinition());
            element.Children.Add(control);

            formation["Midfilder1"]--;
        }

        private int DefenseIndex = 0;
        private void AddToDefense(Player player)
        {
            PlayerControl control = new PlayerControl(player);
            control.Style = (Style)this.FindResource("PlayerControlsAnimation");

            element = (team == "Home_Team")
                ? LeftDefense : RightDefense;

            Grid.SetRow(control, DefenseIndex);
            DefenseIndex++;

            element.RowDefinitions.Add(new RowDefinition());
            element.Children.Add(control);

            formation["Defense"]--;
        }

        private void ResetIndexes()
        {
            DefenseIndex = 0;
            Midfilder1Index = 0;
            Midfilder2Index = 0;
            AttckIndex = 0;
        }

        private Dictionary<string, int> ReadFormation(string formation)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            formation = formation.Replace("-", "");
            for (int i = 0; i < formation.Length;i++)
            {
                if(int.TryParse(formation[i].ToString(), out int number))
                {
                    if (i == 0)
                        result.Add("Defense", number);

                    else if (i == 1 && formation.Length < 4)
                        result.Add("Midfilder1", number);

                    else if(i == 1 && formation.Length > 3)
                        result.Add("Midfilder1", number);

                    else if (i == 2 && formation.Length > 3)
                        result.Add("Midfilder2", number);

                    else
                        result.Add("Attack", number);
                }
            }

            return result;
        }

        private void HomeTeamStatistics_Click(object sender, RoutedEventArgs e)
        {
            TeamStatistics teamStatistics = new TeamStatistics(match.Home_team);

            teamStatistics.Owner = this;            
            teamStatistics.ShowDialog();

        }
        private void AwayTeamStatistics_Click(object sender, RoutedEventArgs e)
        {
            TeamStatistics teamStatistics = new TeamStatistics(match.Away_team);

            teamStatistics.Owner = this;
            teamStatistics.ShowDialog();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= Window_Closing;

            _manager.Next(new MainWindow(_manager));

            Close();
        }
    }
}
