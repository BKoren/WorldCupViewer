using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Exceptions;
using System.Collections.Generic;
using WorldCup.DataLayer.Models;
using WorldCup.WinForms.Dialogs;

namespace WorldCup.WinForms
{
    public partial class TeamSelection : Base
    {        
        public TeamSelection(FormManager manager) : base(manager)
        {
            InitializeComponent();            
            SetType(Type.Regular);

            LanguageManager.ApplyLanguage();
        }

        private void TeamSelection_Load(object sender, EventArgs e)
        {
            labelTitle.Text = Resources.Title;
            labelTitle.Font = TitleFont;

            labelOption.Text = Resources.TextTeamSelector;
            labelOption.Font = TextFont;

            comboBoxTeamSelector.IntegralHeight = false;
            comboBoxTeamSelector.MaxDropDownItems = 15;

            btnNext.Text = Resources.BtnNext;           
        }

        private static List<Team> teams = new List<Team>();
        private async Task LoadOperation()
        {
            try
            {
                using (DataHandler dataBase = new DataHandler())
                {
                    using (DataLoader loader = new DataLoader(dataBase, DataLoader.Type.Team))
                    {
                        await loader.UploadData();

                        teams?.Clear();
                        teams.AddRange(dataBase.Teams);

                        SettingsManager.LoadFavoriteTeam();
                        SettingsManager.TeamFavorite = dataBase.Teams.Find(team =>
                            team.Id == SettingsManager.TeamFavoriteId);

                        DisplayTeams();      
                    }
                }
            }
            catch(DataAccessException error)
            {
                DisplayErrorMessage(error);

                _manager.TransitionNext(new Settings.StartUp(_manager));                
                _manager.AbortForm = true;
            }
            catch(Exception error)
            {
                DisplayErrorMessage(error);
            }
        }

        private void DisplayTeams()
        {
            teams.Sort();
            comboBoxTeamSelector.Items.AddRange(teams.ToArray());

            if (SettingsManager.TeamFavorite is null)
            {
                comboBoxTeamSelector.SelectedIndex = 0;
            }

            else
            {
                comboBoxTeamSelector.SelectedIndex =
                    comboBoxTeamSelector.FindString(SettingsManager.TeamFavorite.ToString());
            }
        }

        public override async void ShowAsync()
        {
            if (_manager.Loading && (teams.Count == 0 || SettingsManager.CategoryIsChanged))
            {
                using (Loading loading = new Loading())
                {
                    loading.Show();
                    loading.Refresh();

                    await LoadOperation();                    
                }

                _manager.Loading = false;
            }
            
            else
            {
                DisplayTeams();
            }

            base.ShowAsync();            
        }

        private Object selectedTeam;
        private void TeamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeam = comboBoxTeamSelector.Items[comboBoxTeamSelector.SelectedIndex];
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (selectedTeam != null)
            {
                SettingsManager.TeamFavorite = selectedTeam;               

                _manager.Loading = true;
                _manager.TransitionNext(new PlayerSelection(_manager));
            }

            else
            {
                MessageBox.Show(
                    "You can't continue unless a team is chosen!\n",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            }
        }
    }
}
