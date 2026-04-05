using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Exceptions;
using WorldCup.DataLayer.Models;
using WorldCup.WinForms.Controls;
using WorldCup.WinForms.Dialogs;

namespace WorldCup.WinForms
{
    public partial class PlayerSelection : Base
    {
        public event EventHandler ClickHandler;

        internal static List<Match> Matches;
        internal static List<Player> Players;

        private List<PlayerControl> MainPlayerControls = new List<PlayerControl>();
        
        public PlayerSelection(FormManager manager) : base(manager)
        {
            InitializeComponent();

            SetType(Type.Regular);

            this.SuspendLayout();

            panelFavoritePlayers.ControlAdded += PanelFavoritePlayersAction;
            panelPlayerSelection.ControlAdded += PanelPlayerSelectionAction;
            panelFavoritePlayers.ControlRemoved += PanelFavoritePlayersAction;
            panelPlayerSelection.ControlRemoved += PanelPlayerSelectionAction;

            panelPlayerSelection.DragLeave += PanelPlayerSelection_DragLeave;
            panelFavoritePlayers.DragEnter += PanelFavoritePlayers_DragEnter;

            panelFavoritePlayers.DragLeave += PanelFavoritePlayers_DragLeave;
            panelPlayerSelection.DragEnter += PanelPlayerSelection_DragEnter;

            panelPlayerSelection.DragDrop += PanelPlayerSelection_DragDrop;
            panelFavoritePlayers.DragDrop += PanelFavoritePlayers_DragDrop;

            ClickHandler += PanelAction;
        }
        private void PlayerSelection_Load(object sender, EventArgs e)
        {
            labelTitle.Text = Resources.TextPlayerSelector;
            labelTitle.Font = TitleFont;
            
            labelFavorites.Text = Resources.TextFavorites;
            labelFavoriteTeam.Text = SettingsManager.TeamFavorite.ToString();

            labelFavoriteTeam.Font = TextFontBig;
            labelFavorites.Font = TextFontBig;

            labelSelectionMarkImg.Text = Resources.TextMarkImg;
            labelSelectionMarkName.Text = Resources.TextMarkName;
            labelSelectionMarkShirtNumber.Text= Resources.TextMarkShirtNumber;
            labelSelectionMarkPosition.Text= Resources.TextMarkPosition;
            labelSelectionMarkCapetain.Text = Resources.TextMarkCapetain;

            labelFavoriteMarkImg.Text = Resources.TextMarkImg;
            labelFavoriteMarkName.Text = Resources.TextMarkName;
            labelFavoriteMarkShirtNumber.Text = Resources.TextMarkShirtNumber;
            labelFavoriteMarkPosition.Text = Resources.TextMarkPosition;
            labelFavoriteMarkCapetain.Text = Resources.TextMarkCapetain;

            btnShowRatings.Text = Resources.BtnShowRankings;
            btnSettings.Text = Resources.BtnSettings;
            btnBack.Text = Resources.BtnBack;
            btnExit.Text = Resources.BtnExit;

            this.ResumeLayout(true);
        }

        private async Task LoadOperation()
        {
            try
            {
                using (var dataBase = new DataHandler())
                {
                    using (var loader = new DataLoader(dataBase, DataLoader.Type.Match))
                    {
                        await loader.UploadData();

                        Matches = new List<Match>(dataBase.Matches);

                        await LoadPlayers();
                    }
                }
            }
            catch (DataAccessException error)
            {
                DisplayErrorMessage(error);
                
                _manager.TransitionNext(new Settings.StartUp(_manager));
                _manager.AbortForm = true;
            }
            catch (Exception error)
            {
                DisplayErrorMessage(error);
            }
        }
        private async Task LoadPlayers()
        {
            List<Player> players = await Task.Run(() =>
            {
                Match match = Matches.Find(item =>
                    item.Home_team_country == SettingsManager.TeamFavoriteName ||
                    item.Away_team_country == SettingsManager.TeamFavoriteName
                );

                Statistics statistics = match.Away_team_statistics.Country == SettingsManager.TeamFavoriteName
                    ? match.Away_team_statistics
                    : match.Home_team_statistics;

                Players = statistics.GetPlayers();

                return statistics.GetPlayers();
            });

            MainPlayerControls = PlayerToControls(players);

            SettingsManager.LoadFavoritePlayers();
            if (SettingsManager.PlayersFavorite != null
            && (SettingsManager.PlayersFavorite.All(player =>
            player.Country == SettingsManager.TeamFavoriteName)))
            {
                List<PlayerControl> favoritePlayerControls
                    = PlayerToControls(SettingsManager.PlayersFavorite);

                foreach (PlayerControl playerControl in favoritePlayerControls)
                {
                    MainPlayerControls.Remove(
                        MainPlayerControls.Find(player =>
                            player.ColumnContent2 == playerControl.ColumnContent2 &&
                            player.ColumnContent3 == playerControl.ColumnContent3
                        )
                    );

                    panelFavoritePlayers.Controls.Add(playerControl);
                }
            }

            AddControlsToPanel(panelPlayerSelection, MainPlayerControls); 
        }
        public override async void ShowAsync()
        {
            if (_manager.LoadingNessecary 
            || (_manager.Loading && (Matches != null || !SettingsManager.CategoryIsChanged)))
            {
                using (Loading loading = new Loading())
                {
                    loading.Show();
                    loading.Refresh();

                    await LoadOperation();
                }

                _manager.Loading = false;
                _manager.LoadingNessecary = false;
            }

            else
                await LoadPlayers(); 

            base.ShowAsync();
        }
        private List<PlayerControl> PlayerToControls(List<Player> players)
        {
            List<PlayerControl> result = new List<PlayerControl>();
            foreach (Player player in players)
            {
                PlayerControl playerControl = new PlayerControl
                {
                    Dock = DockStyle.Top,
                    ID = player.Shirt_Number,
                    ColumnContent1 = ImgHandeler.FindImg(player.Name, player.Shirt_Number),
                    ColumnContent2 = player.Name,
                    ColumnContent3 = player.Shirt_Number.ToString(),
                    ColumnContent4 = player.Position,
                    IsFavorite = player.Is_Favorite,
                    ColumnContent5Bool = player.Captain
                };

                playerControl.ClickHandler += PanelAction;

                result.Add(playerControl);
            }

            return result;
        }

        private List<PlayerControl> ProcessPlayerControls = new List<PlayerControl>();
        private void BtnArrowLeft_Click(object sender, EventArgs e)
        {
            ProcessPlayerControls = PlayerControl.PressedPlayers;

            if (ProcessPlayerControls.Any(control => control.IsFavorite != true))
                return;

            AddControlsToPanel(panelPlayerSelection, ProcessPlayerControls);
            ProcessPlayerControls.Clear();    
        }
        private void BtnArrowRight_Click(object sender, EventArgs e)
        {
            ProcessPlayerControls = PlayerControl.PressedPlayers;

            if (ProcessPlayerControls.Any(control => control.IsFavorite != false))
                return;

            if (panelFavoritePlayers.Controls.Count + ProcessPlayerControls.Count <= 3)
            {
                AddControlsToPanel(panelFavoritePlayers, ProcessPlayerControls);
            }

            else
            {
                MessageBox.Show($"There can be only 3 favorite players!");

                ProcessPlayerControls.ForEach(control =>
                    control.SimulateClick());
            }

            ProcessPlayerControls.Clear();
        }

        private bool previousControl = false;
        private void PanelAction(object sender, EventArgs e)
        {
            PlayerControl control = (PlayerControl)sender;

            if (previousControl != control.IsFavorite)
            {
                if (control.IsFavorite)
                {
                    foreach (PlayerControl item in panelPlayerSelection.Controls)
                    {
                        if (item.click)
                        {
                            ClickHandler -= PanelAction;
                            item.SimulateClick();
                            item.UpdatePressedList();
                        }
                    }
                }

                else
                {
                    foreach (PlayerControl item in panelFavoritePlayers.Controls)
                    {
                        if (item.click)
                        {
                            ClickHandler -= PanelAction;
                            item.SimulateClick();
                            item.UpdatePressedList();
                        }
                    }
                }

                ClickHandler += PanelAction;
            }

            previousControl = control.IsFavorite;

        }
        private void PanelFavoritePlayersAction(object sender, ControlEventArgs e)
        {
            foreach (PlayerControl control in panelFavoritePlayers.Controls)
            {
                control.IsFavorite = true;

                if (control.click)
                    control.SimulateClick();
            }           
        }
        private void PanelPlayerSelectionAction(object sender, ControlEventArgs e)
        {
            foreach (PlayerControl control in panelPlayerSelection.Controls)
            {
                control.IsFavorite = false;
                
                if (control.click)
                    control.SimulateClick();
            }
        }

        internal bool Transfer = false;
        private void PanelPlayerSelection_DragLeave(object sender, EventArgs e)
            => Transfer = true;
        private void PanelFavoritePlayers_DragLeave(object sender, EventArgs e)
            => Transfer = true;
        
        private void PanelFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (Transfer)
            {
                if (panelFavoritePlayers.Controls.Count + ProcessPlayerControls.Count <= 3)
                {
                    AddControlsToPanel(panelFavoritePlayers, ProcessPlayerControls);                   
                }

                else
                {
                    MessageBox.Show($"There can be only 3 favorite players!");

                    ProcessPlayerControls.ForEach(control =>
                        control.SimulateClick());
                }
            
                ProcessPlayerControls.Clear();
            }

            Transfer = false;
        }
        private void PanelPlayerSelection_DragDrop(object sender, DragEventArgs e)
        {
            if (Transfer)
            {
                AddControlsToPanel(panelPlayerSelection, ProcessPlayerControls);
                ProcessPlayerControls.Clear();                           
            }

            Transfer = false;
        }
        private void PanelFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            ProcessPlayerControls = (List<PlayerControl>)
                e.Data.GetData(typeof(List<PlayerControl>));
        }
        private void PanelPlayerSelection_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            ProcessPlayerControls = (List<PlayerControl>)
                e.Data.GetData(typeof(List<PlayerControl>));
        }
        private void AddControlsToPanel(Panel panel, List<PlayerControl> controls)
        {
            if (controls.Count != 0)
            {
                panel.Visible = false;

                foreach (PlayerControl control in panel.Controls)
                    controls.Add(control);

                panel.Controls.Clear();
                controls.Sort();
                controls.Reverse();

                foreach (PlayerControl control in controls)
                    panel.Controls.Add(control);

                panel.Visible = true;
            }
        }

        private void SaveFavoritePlayers()
        {
            Players.ForEach(player => player.Is_Favorite = false);

            List<Player> list = new List<Player>();
            foreach (PlayerControl control in panelFavoritePlayers.Controls)
            {
                list.Add(
                    new Player
                    {
                        PlayerImg = ImgHandeler.Img,
                        Name = control.ColumnContent2,
                        Captain = control.ColumnContent5Bool,
                        Shirt_Number = int.Parse(control.ColumnContent3),
                        Position = control.ColumnContent4,
                        Country = SettingsManager.TeamFavoriteName
                    }
                );

                foreach(Player player in Players)
                {
                    if(player.Name == control.ColumnContent2
                    && player.Shirt_Number == int.Parse(control.ColumnContent3))
                    {
                        player.Is_Favorite = true;
                    }
                }
            }

            SettingsManager.PlayersFavorite = list;
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            SaveFavoritePlayers();

            _manager.Loading = false;
            _manager.TransitionNext(new TeamSelection(_manager));
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (panelFavoritePlayers.Controls.Count < 3)
            {
                MessageBox.Show("You must select 3 favourite players before continuing!");
                return;
            }
            else
            {
                this.Close();
            }
        }
        protected override void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.FormBase_FormClosing(sender, e);

            SaveFavoritePlayers();
        }
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            _manager.TransitionNext(new Settings.Update(_manager));
        }
        private void BtnShowRatings_Click(object sender, EventArgs e)
        {
            if (panelFavoritePlayers.Controls.Count < 3)
            {
                MessageBox.Show("You must select 3 favourite players before continuing!");
                return;
            }
            else
            {
                SaveFavoritePlayers();

                _manager.Loading = true;
                _manager.TransitionNext(new PlayerRank(_manager));
            }
        }
    }
}
