using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Models;
using WorldCup.WinForms.Controls;
using WorldCup.WinForms.Dialogs;

namespace WorldCup.WinForms
{
    public partial class PlayerRank : Base
    {
        private List<Player> Players = new List<Player>();
        private List<Match> Matches = new List<Match>();

        public PlayerRank(FormManager manager) : base(manager)
        {
            InitializeComponent();
            SetType(Type.Regular);

            PhotoUpload.RemoveImg += ActivatorRemoval;
            PhotoUpload.RefreshForm += ActivatorRefresh;
        }

        private void PlayerRank_Load(object sender, EventArgs e)
        {
            labelTitle.Text = Resources.Title;
            labelTitle.Font = TitleFont;

            labelRankOption.Text = Resources.TextRankCriteria;
            labelRankOption.Font = TextFontSmall;

            labelCategoryOption.Text = Resources.TextCategoryOption;
            labelCategoryOption.Font = TextFontSmall;
            
            labelSetImageOption.Text = Resources.TextSetImage;
            labelSetImageOption.Font = TextFont;

            btnMatches.Text = Resources.BtnMatches;
            btnPlayers.Text = Resources.BtnPlayers;
            btnRankGoal.Text = Resources.BtnRankGoal;
            btnRankCard.Text = Resources.BtnRankCard;
            btnBack.Text = Resources.BtnBack;
            btnPrint.Text = Resources.BtnPrintRankings;

            labelMark1.Text = Resources.TextMarkImg;
            labelMark2.Text = Resources.TextMarkName;
            labelMark3.Text = Resources.TextMarkAppearances;
            labelMark4.Text = Resources.TextMarkGoals;
            labelMark5.Text = Resources.TextMarkCards;

            DisplayPlayers();
        }

        void ActivatorRemoval(object sender, EventArgs e)
        {
            PlayerControl controlSender = (PlayerControl)sender;

            foreach (PlayerControl control in panelControlRanking.Controls)
            {
                if (control.ColumnContent2 == controlSender.ColumnContent2
                && control.ID == controlSender.ID)
                {
                    control.ColumnContent1?.Dispose();
                    control.ColumnContent1 = null;
                    
                    control.ColumnContent1 = Resources.ImgDefault;
                }
            }          
        }       
        void ActivatorRefresh(object sender, EventArgs e)
        {
            DisplayPlayers();
        }           

        private void DisplayPlayers()
        {
            layoutRankMarks.Visible = false;
            panelControlRanking.Visible = false;

            List<PlayerControl> playerControls = new List<PlayerControl>
                (PlayerToControls(Players));

            panelControlRanking.Controls.Clear();
            foreach (PlayerControl player in playerControls)
            {
                panelControlRanking.Controls.Add(player);
            }

            panelControlRanking.Visible = true;
            layoutRankMarks.Visible = true;
        }

        private void LoadOperation()
        {          
            Players = PlayerSelection.Players;
            foreach (Player player in Players)
            {
                player.Games = 0;
                player.Goals = 0;
                player.Yellow_Cards = 0;
            }

            Matches = PlayerSelection.Matches
                .Where(match =>
                    match.Home_team_country == SettingsManager.TeamFavoriteName ||
                    match.Away_team_country == SettingsManager.TeamFavoriteName
                ).ToList();


            for (int i = 0; i < Matches.Count; i++)
            {
                Statistics statistics =
                    Matches[i].Home_team_country == SettingsManager.TeamFavoriteName
                    ? Matches[i].Home_team_statistics
                    : Matches[i].Away_team_statistics;

                List<Event> events =
                    Matches[i].Home_team_country == SettingsManager.TeamFavoriteName
                    ? Matches[i].Home_team_events
                    : Matches[i].Away_team_events;


                foreach (Player player in Players)
                {
                    if (statistics.Starting_eleven.Any(item => item.Name == player.Name) ||
                        events.Any(e =>
                            e.Player == player.Name &&
                            e.Type_of_event == "substitution-in")
                        )
                    {
                        player.Games++;
                    }

                    foreach (Event e in events)
                    {
                        if (e.Player == player.Name)
                        {
                            if (e.Type_of_event == "goal" || e.Type_of_event == "goal-penalty")                            
                                player.Goals++;                            

                            if (e.Type_of_event == "yellow-card")
                                player.Yellow_Cards++;
                        }
                    }
                }
            }
           
        }
        public  override void ShowAsync()
        {           
            using (Loading loading = new Loading())
            {
                loading.Show();
                loading.Refresh();

                LoadOperation();
                loading.Close();
            }

            _manager.Loading = false;

            base.ShowAsync();
        }

        private List<MatchControl> MatchToControls(List<Match> matches)
        {
            List<MatchControl> result = new List<MatchControl>();
            foreach (Match match in matches) 
            {
                MatchControl matchControl = new MatchControl
                { 
                    Dock = DockStyle.Top,
                    ColumnContent1 = match.Location,
                    ColumnContent2 = match.Home_team_country,
                    ColumnContent3 = match.Away_team_country,
                    ColumnContent4 = match.Attendance,
                    ColumnContent5 = match.Datetime
                                            .Replace('T', '\n')
                                            .Remove(match.Datetime.Length - 4)
                };

                matchControl.Font = new System.Drawing.Font(
                    new System.Drawing.FontFamily("Microsoft Sans Serif"), 9);

                result.Add(matchControl);
            }

            result.Sort((a, b) => a.ColumnContent4.CompareTo(b.ColumnContent4));

            return result;
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
                    ColumnContent3 = player.Games.ToString(),
                    ColumnContent4 = player.Goals.ToString(),
                    ColumnContent5 = player.Yellow_Cards.ToString(),
                    IsFavorite = player.Is_Favorite
                };

                if (player.Is_Favorite)
                    playerControl.StarImg(true);

                playerControl.Font = new System.Drawing.Font(
                    new System.Drawing.FontFamily("Microsoft Sans Serif"), 10);

                playerControl.ModifyForRanking();

                result.Add(playerControl);
            }

            result.Sort();
            result.Reverse();

            return result;
        }

        private bool MatchActive = false;
        private void BtnMatches_Click(object sender, EventArgs e)
        {
            PlayersActive = false;

            if (MatchActive)
                return;

            MatchActive = true;

            layoutRankMarks.Visible = false;
            panelControlRanking.Visible = false;
            panelControlRanking.Controls.Clear();

            btnRankGoal.Enabled = false;
            btnRankGoal.Visible = false;
            btnRankCard.Enabled = false;
            btnRankCard.Visible = false;
            labelRankOption.Enabled = false;
            labelRankOption.Visible = false;
            labelSetImageOption.Visible = false;
            
            labelFavoriteTeam = new Label();
            layoutBottomUpper.ColumnStyles[2].Width = 50;
            layoutBottomUpper.ColumnStyles[3].Width = 0;
            layoutBottomUpper.Controls.Add(labelFavoriteTeam, 2, 0);
            
            labelFavoriteTeam.Text = SettingsManager.TeamFavorite.ToString();
            labelFavoriteTeam.Font = TextFontBig;
            labelFavoriteTeam.Anchor = AnchorStyles.None;
            labelFavoriteTeam.AutoSize = true;
           
            layoutRankMarks.ColumnStyles[0].Width = 22;
            layoutRankMarks.ColumnStyles[1].Width = 22;
            layoutRankMarks.ColumnStyles[2].Width = 20;
            layoutRankMarks.ColumnStyles[3].Width = 15.8F;
            layoutRankMarks.ColumnStyles[4].Width = 18;
            layoutRankMarks.ColumnStyles[5].Width = 2.2F;

            if (layoutRankMarks.ColumnCount == 7)
            {
                layoutRankMarks.ColumnStyles.RemoveAt(6);
                layoutRankMarks.ColumnCount--;
            }

            labelMark1.Text = Resources.TextMarkLocation;
            labelMark2.Text = Resources.TextMarkHomeTeam;
            labelMark3.Text = Resources.TextMarkAwayTeam;
            labelMark4.Text = Resources.TextMarkVisitors;
            labelMark5.Text = Resources.TextMarkDate;

            List<MatchControl> matchControls = new List<MatchControl>
                (MatchToControls(Matches));

            panelControlRanking.Controls.Clear();
            foreach (MatchControl match in matchControls)
            {
                panelControlRanking.Controls.Add(match);
            }

            panelControlRanking.Visible = true;
            layoutRankMarks.Visible = true;
        }

        private bool PlayersActive = true;
        private void BtnPlayers_Click(object sender, EventArgs e)
        {
            if (PlayersActive)
                return;

            layoutRankMarks.Visible = false;
            panelControlRanking.Visible = false;

            MatchActive = false;

            PlayersActive = true;
            panelControlRanking.Controls.Clear();

            labelFavoriteTeam?.Dispose();    
            layoutBottomUpper.ColumnStyles[2].Width = 25;
            layoutBottomUpper.ColumnStyles[3].Width = 25;

            btnRankGoal.Enabled = true;
            btnRankGoal.Visible = true;
            btnRankCard.Enabled = true;
            btnRankCard.Visible = true;
            labelRankOption.Enabled = true;
            labelRankOption.Visible = true;
            labelSetImageOption.Visible = true;

            layoutRankMarks.ColumnStyles[0].Width = 12.5F;
            layoutRankMarks.ColumnStyles[1].Width = 28.3F;
            layoutRankMarks.ColumnStyles[2].Width = 15;
            layoutRankMarks.ColumnStyles[3].Width = 15;
            layoutRankMarks.ColumnStyles[4].Width = 15;          
            layoutRankMarks.ColumnStyles[5].Width = 12.5F;

            if (layoutRankMarks.ColumnCount == 6)
            {
                layoutRankMarks.ColumnCount++;
                layoutRankMarks.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 1.7F));
            }

            labelMark1.Text = Resources.TextMarkImg;
            labelMark2.Text = Resources.TextMarkName;
            labelMark3.Text = Resources.TextMarkAppearances;
            labelMark4.Text = Resources.TextMarkGoals;
            labelMark5.Text = Resources.TextMarkCards;

            DisplayPlayers();
        }

        private void BtnRankGoal_Click(object sender, EventArgs e)
        {
            panelControlRanking.Visible = false;

            List<PlayerControl> controls = new List<PlayerControl>();
            foreach(PlayerControl control in panelControlRanking.Controls)            
                controls.Add(control);                        

            controls.Sort((a, b) => 
                int.Parse(a.ColumnContent4).CompareTo(int.Parse(b.ColumnContent4)));

            foreach(PlayerControl control in controls)
                panelControlRanking.Controls.Add(control);

            panelControlRanking.Visible = true;
        }
        private void BtnRankCard_Click(object sender, EventArgs e)
        {
            panelControlRanking.Visible = false;

            List<PlayerControl> controls = new List<PlayerControl>();
            foreach (PlayerControl control in panelControlRanking.Controls)
                controls.Add(control);

            controls.Sort((a, b) =>
                int.Parse(a.ColumnContent5).CompareTo(int.Parse(b.ColumnContent5)));

            foreach (PlayerControl control in controls)
                panelControlRanking.Controls.Add(control);

            panelControlRanking.Visible = true;
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            _manager.LoadingNessecary = true;
            _manager.TransitionNext(new PlayerSelection(_manager));
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            using (Loading loading = new Loading())
            {
                loading.Show();
                loading.Refresh();

                string path =
                        Path.GetFullPath(
                            Path.Combine(
                                AppDomain.CurrentDomain.BaseDirectory,
                                @"..\..\..\WorldCup.DataLayer\Resources\PDF\ControlsInPDF.pdf"
                            )
                        );

                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));


                document.Open();
                document.NewPage();

                iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                iTextSharp.text.Font small = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                string title = MatchActive == true ? "Match Ranking Document" : "Players Ranking Document";

                PdfPTable table = (PlayersActive == true) ? new PdfPTable(6) : new PdfPTable(5);
                PdfPCell cell = new PdfPCell()
                {
                    Phrase = new Phrase(title),
                    Colspan = 6,
                    HorizontalAlignment = 1,
                    Padding = 12.5F
                };
                table.AddCell(cell);

                PdfPCell baseCell = new PdfPCell()
                {
                    Padding = 5,                  
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };

                table.AddCell(new PdfPCell(baseCell) { Phrase = new Phrase(labelMark1.Text, font) });
                table.AddCell(new PdfPCell(baseCell) { Phrase = new Phrase(labelMark2.Text, font) });
                table.AddCell(new PdfPCell(baseCell) { Phrase = new Phrase(labelMark3.Text, font) });
                table.AddCell(new PdfPCell(baseCell) { Phrase = new Phrase(labelMark4.Text, font) });
                table.AddCell(new PdfPCell(baseCell) { Phrase = new Phrase(labelMark5.Text, labelMark5.Text == "Yellow Cards" ? small : font) });
               
                if(PlayersActive)
                    table.AddCell(new PdfPCell(baseCell) { Phrase = new Phrase("") });

                List<Control> controls = new List<Control>();
                foreach (Control control in panelControlRanking.Controls)                
                    controls.Add(control);
                
                controls.Reverse();
                foreach (Control control in controls)
                {
                    if (PlayersActive)
                    {
                        PlayerControl playerControl = control as PlayerControl;

                        using (MemoryStream stream = new MemoryStream())
                        {
                            playerControl.ColumnContent1.Save
                                (stream, System.Drawing.Imaging.ImageFormat.Png);

                            iTextSharp.text.Image pdfImg =
                                iTextSharp.text.Image.GetInstance(stream.ToArray());
                            pdfImg.ScaleAbsoluteWidth(50f);
                            pdfImg.ScaleAbsoluteHeight(50f);

                            PdfPCell imgCell = new PdfPCell(pdfImg, fit: false);
                            imgCell.Padding = 8.5F;
                            imgCell.Border = PdfPCell.BOX;   
                            imgCell.BackgroundColor = new BaseColor(173, 216, 230);
                            table.AddCell(imgCell);
                        }
                    }

                    else if (MatchActive)
                    {
                        table.AddCell(new PdfPCell(baseCell)
                        {
                            Phrase = new Phrase((control as MatchControl).ColumnContent1, font)
                        });
                    }

                    table.AddCell(new PdfPCell(baseCell)
                    {
                        Phrase = new Phrase(
                            (control is PlayerControl)
                                ? (control as PlayerControl).ColumnContent2
                                : (control as MatchControl).ColumnContent2,
                                  (control is PlayerControl) ? small : font
                        )
                    });

                    table.AddCell(new PdfPCell(baseCell)
                    {
                        Phrase = new Phrase(
                            (control is PlayerControl)
                                ? (control as PlayerControl).ColumnContent3
                                : (control as MatchControl).ColumnContent3,
                            font
                        )
                    });

                    table.AddCell(new PdfPCell(baseCell)
                    {
                        Phrase = new Phrase(
                            (control is PlayerControl)
                                ? (control as PlayerControl).ColumnContent4
                                : (control as MatchControl).ColumnContent4,
                            font
                        )
                    });

                    table.AddCell(new PdfPCell(baseCell)
                    {
                        Phrase = new Phrase(
                            (control is PlayerControl)
                                ? (control as PlayerControl).ColumnContent5
                                : (control as MatchControl).ColumnContent5,
                                  (control is PlayerControl) ? font : small                                
                        )
                    });

                    if(PlayersActive)
                    {
                        PlayerControl playerControl = control as PlayerControl;

                        using (MemoryStream stream = new MemoryStream())
                        {
                            playerControl.Star.Save
                                (stream, System.Drawing.Imaging.ImageFormat.Png);

                            if (playerControl.IsFavorite)
                            {
                                iTextSharp.text.Image pdfImg =
                                    iTextSharp.text.Image.GetInstance(stream.ToArray());

                                pdfImg.ScaleToFit(20f, 20f);

                                PdfPCell imgCell = new PdfPCell(pdfImg);
                                imgCell.Padding = 5;
                                imgCell.Border = PdfPCell.BOX;
                                imgCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                imgCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                                table.AddCell(imgCell);
                            }
                            else
                                table.AddCell(new PdfPCell(baseCell));
                        }
                    }
                }
                
                document.Add(table);

                document.Close();

                try
                {
                    Process.Start(path);
                }
                catch (Exception error)
                {
                    DisplayErrorMessage(error);
                }

                loading.Close();
            }
        }        
    }
}