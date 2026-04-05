using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Exceptions;
using WorldCup.DataLayer.Models;
using WorldCup.WPF.Dialogs;
using WorldCup.WPF.Windows;

namespace WorldCup.WPF
{
    public partial class MainWindow : Base
    {             
        public MainWindow(WindowManager manager) : base(manager)
        {            
            InitializeComponent();            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e )
        {
            title.Text = DataLayer.Resources.Title;

            btnSetMatch.Text = DataLayer.Resources.BtnSetMatch;
            btnSetTeam.Text = DataLayer.Resources.BtnSetTeam;
            btnSettings.Content = DataLayer.Resources.BtnSettings;
            btnDetailStatisticsText.Text = DataLayer.Resources.BtnDetailStatistics;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            header.Height = this.ActualHeight * 0.125;
            header.Width = this.ActualWidth * 0.7;

            content.Height = this.ActualHeight * 0.5;
            content.Width = this.ActualWidth * 0.8;

            layoutFavoriteMatch.Height = this.ActualHeight * 0.125;
            layoutFavoriteMatch.Width = this.ActualWidth * 0.55;
            
            layoutFavoriteTeam.Height = this.ActualHeight * 0.125;
            layoutFavoriteTeam.Width = this.ActualWidth * 0.55;            

            footer.Height = this.ActualHeight * 0.15;
            footer.Width = this.ActualWidth * 0.7;

            btnSettings.Height = this.ActualHeight * 0.1; 
            btnSettings.Width = this.ActualWidth * 0.125;

            btnDetailStatistics.Height = this.ActualHeight * 0.1;
            btnDetailStatistics.Width = this.ActualWidth * 0.2;

            Resources["BtnFontSize"] = Math.Min(this.ActualWidth, this.ActualHeight) * 0.025;

            Resources["BtnWindowHeight"] = this.ActualHeight * 0.125;
            Resources["BtnWindowWidth"] = this.ActualWidth * 0.20;
        }

        internal static List<Match> allMatches = new List<Match>();

        internal static List<Team> teams = new List<Team>();
        internal static List<Match> matches = new List<Match>();

        private async Task LoadOperation()
        {
            try
            {
                using (DataHandler dataBase = new DataHandler())
                {
                    using (DataLoader loader = new DataLoader(dataBase, DataLoader.Type.Team))
                    {
                        await loader.UploadData();

                        teams = new List<Team>(dataBase.Teams);

                        SettingsManager.LoadFavoriteTeam();
                        SettingsManager.TeamFavorite = teams.Find(team =>
                            team.Id == SettingsManager.TeamFavoriteId);
                    }

                    using (DataLoader loader = new DataLoader(dataBase, DataLoader.Type.Match))
                    {
                        await loader.UploadData();

                        allMatches = new List<Match>(dataBase.Matches);
                        
                        SettingsManager.LoadFavoriteMatch();
                        SettingsManager.MatchFavorite = allMatches.Find(match =>
                            match.Home_team_country == SettingsManager.MatchFavorite?.Home_team_country &&
                            match.Away_team_country == SettingsManager.MatchFavorite?.Away_team_country
                        );
                    }
                }
            }
            catch (DataAccessException error)
            {
                string AdditionalInfo =
                    ExceptionProcessor.ProcessException(error);

                MessageBox.Show(
                    $"Error while loading form!\n" +
                    $"{error.Message}" +
                    $"Attention: Method switch is possible only in windows form application!\n" +
                     AdditionalInfo,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                SettingsManager.StartUpIsNessecary = true;
                _manager.Next(new Settings.StartUp(_manager));

                Base.AbortWindow = true;
            }
            catch (Exception error)
            {
                DisplayErrorMessage(error);
            }
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= Window_Closing;
            _manager.Next(new Settings.Update(_manager));

            Close();
        }
        private void BtnDetailStatistics_Click(object sender, RoutedEventArgs e)
        {
            if(SettingsManager.TeamFavorite is null || SettingsManager.MatchFavorite is null)
            {
                MessageBox.Show("You need to set favorite team and match to continue!");                
            }

            else
            {
                this.Closing -= Window_Closing;

                _manager.Loading = true;
                _manager.Next(new MatchStatistics(_manager));

                Close();
            }
        }
        private void BtnSetTeam_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= Window_Closing;            
            _manager.Next(new TeamSelection(_manager));

            Close();
        }
        private void BtnSetMatch_Click(object sender, RoutedEventArgs e)
        {
            if(SettingsManager.TeamFavorite is null)
            {
                MessageBox.Show("Favorite team need's to be choosen before displaying matches.");                
            }

            else
            {
                this.Closing -= Window_Closing;

                _manager.Next(new MatchSelector(_manager));

                Close();
            }
        }

        public override async void BeforeShow()
        {
            if (_manager.Loading && (teams.Count == 0 || SettingsManager.CategoryIsChanged))
            {
                Loading loading = new Loading();
                loading.Show();

                await LoadOperation();
                UpdateFavorites();

                loading.Close();

                _manager.Loading = false;
            }

            else
                UpdateFavorites();

            base.BeforeShow();
        }

        private void UpdateFavorites()
        {
            FavoriteTeamText.Text = SettingsManager.TeamFavorite is null
                ? DataLayer.Resources.TextNoTeamSet
                : SettingsManager.TeamFavorite.ToString();

            FavoriteMatchText.Text = (SettingsManager.MatchFavorite is null || 
                SettingsManager.MatchFavorite.Home_team.Country is null ||
                SettingsManager.MatchFavorite.Home_team.Country is null
            )
                ? DataLayer.Resources.TextNoMatchSet
                : SettingsManager.MatchFavorite.ToString();

            matches = allMatches.Where(match =>
                match.Home_team_country == SettingsManager.TeamFavoriteName ||
                match.Away_team_country == SettingsManager.TeamFavoriteName
            ).ToList();
        }
    }
}
