using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldCup.DataLayer;

namespace WorldCup.WinForms.Controls
{
    public partial class PlayerControl : UserControl, IComparable<PlayerControl>
    {
        private EventHandler leaveHandler;
        private MouseEventHandler moveHandler;

        public event EventHandler ClickHandler;

        public static List<PlayerControl> PressedPlayers = new List<PlayerControl>();

        public PlayerControl()
        {
            InitializeComponent();

            leaveHandler = new EventHandler(PlayerControl_MouseLeave);
            moveHandler = new MouseEventHandler(PlayerControl_MouseMove);

            AddEvents(this);
            ModifyControls(this, Color.White);            

            this.GiveFeedback += PlayerControl_GiveFeedback;
        }

        private bool isFavorite;
        internal bool IsFavorite 
        {
            get => isFavorite;
            set
            {
                StarImg(value);
                isFavorite = value;

                if (isFavorite)
                {
                    layoutPlayerControl.ColumnStyles[0].Width = 19;
                    layoutPlayerControl.ColumnStyles[1].Width = 27;
                    layoutPlayerControl.ColumnStyles[2].Width = 12;
                    layoutPlayerControl.ColumnStyles[3].Width = 20;
                    layoutPlayerControl.ColumnStyles[4].Width = 12;
                    layoutPlayerControl.ColumnStyles[5].Width = 10;                                       
                    layoutPlayerControl.ColumnStyles[5].SizeType = SizeType.Percent;
                    panelImgHolder.Padding = new Padding(4);
                }

                else
                {
                    layoutPlayerControl.ColumnStyles[0].Width = 20;
                    layoutPlayerControl.ColumnStyles[1].Width = 30;
                    layoutPlayerControl.ColumnStyles[2].Width = 15;
                    layoutPlayerControl.ColumnStyles[3].Width = 20;
                    layoutPlayerControl.ColumnStyles[4].Width = 15;
                    layoutPlayerControl.ColumnStyles[5].Width = 0;
                    panelImgHolder.Padding = new Padding(4);
                }
            }
        }        

        private PictureBox star = new PictureBox
        {
            Image = (Image)Resources.ImgStar.Clone(),
            SizeMode = PictureBoxSizeMode.Zoom,
            Anchor = AnchorStyles.None,
            Margin = new Padding(0),
            Size = new Size(40, 25)
        };
        
        internal Image Star
        {
            get => (Image)star.Image.Clone();
        }
        internal void StarImg(bool control)
        {
            if (control)
                layoutPlayerControl.Controls.Add(star, 6, 0);

            else
            {
                layoutPlayerControl.Controls.Remove(star);
            }
        }
   
        
        private int id;
        public int ID
        {
            get => id;
            set => id = value;
        }
        internal Image ColumnContent1
        {
            get => pictureBoxPlayer?.Image;
            set
            {
                pictureBoxPlayer.Image?.Dispose();
                pictureBoxPlayer.Image = null;

                pictureBoxPlayer.Image = value;   
            }
        }
        internal string ColumnContent2 
        {             
            set => labelContent1.Text = value;
            get => labelContent1.Text;
        }   
        internal string ColumnContent3
        {
            get => labelContent2.Text;
            set => labelContent2.Text = value;
        }
        internal string ColumnContent4
        {
            get => labelContent3.Text;
            set => labelContent3.Text = value;
        }
        internal string ColumnContent5
        {
            get => labelContent4.Text;
            set => labelContent4.Text = value;  
        }
        internal bool ColumnContent5Bool
        {
            get => labelContent4.Text == "Yes";

            set => labelContent4.Text = value
                ? "Yes" : "No";
        }

        private void ModifyControls(Control playerControl, Color color)
        {
            foreach (Control control in playerControl.Controls)
            {
                control.BackColor = color;

                if (control.HasChildren)
                    ModifyControls(control, color);
            }
            
            pictureBoxPlayer.BackColor = Color.LightBlue;
            panelImgHolder.BackColor = Color.LightBlue;            
        }
        private void AddEvents(Control playerControl)
        {
            foreach (Control control in playerControl.Controls)
            {
                control.MouseLeave += leaveHandler;
                control.MouseMove += moveHandler;

                control.MouseUp += PlayerControl_MouseUp;
                control.MouseDown += PlayerControl_MouseDown;
                control.Click += PlayerControl_Click;

                if (control.HasChildren)
                    AddEvents(control);
            }

            star.Click += PlayerControl_Click;
            star.MouseLeave += leaveHandler;
            star.MouseMove += moveHandler;
        }

        internal bool click = false;
        internal void SimulateClick()
        {
            click = !click;

            switch (click)
            {
                case true:
                    ModifyControls(this, Color.DarkGray);

                    pictureBoxPlayer.BackColor = Color.DeepSkyBlue;
                    panelImgHolder.BackColor = Color.DeepSkyBlue;
                    star.BackColor = Color.DarkGray;
                break;

                case false:
                    ModifyControls(this, Color.White);

                    pictureBoxPlayer.BackColor = Color.LightBlue;
                    panelImgHolder.BackColor = Color.LightBlue;
                    star.BackColor = Color.White;
                break;
            }
        }

        private bool isDragging = false;
        private bool mouseDown = false;
        private Point mouseDownLocation;
        private void PlayerControl_Click(object sender, EventArgs e)
        {
            ClickHandler?.Invoke(this, e);
            
            SimulateClick();

            UpdatePressedList();
        }
        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            isDragging = false;
            mouseDownLocation = e.Location;
        }
        private void PlayerControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!click)
            {
                ModifyControls(this, Color.LightGray);

                pictureBoxPlayer.BackColor = Color.SkyBlue;
                panelImgHolder.BackColor = Color.SkyBlue;
            }

            if (!mouseDown)
                return;

            if (!isDragging)
            {
                ClickHandler?.Invoke(this, e);

                if(!click)
                    SimulateClick();

                if (Math.Abs(e.X - mouseDownLocation.X) > 5 
                ||  Math.Abs(e.Y - mouseDownLocation.Y) > 5)
                {
                    isDragging = true;
                    
                    UpdatePressedList();
                    DoDragDrop(PressedPlayers, DragDropEffects.Move);
                }
            }      
        }
        private void PlayerControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
                return;

            mouseDown = false;

            if (!isDragging)
            {
                OnClick(EventArgs.Empty);
            }
        }
        private void PlayerControl_MouseLeave(object sender, EventArgs e)
        {         
            if (click)
                return;

            ModifyControls(this, Color.White);

            pictureBoxPlayer.BackColor = Color.LightBlue;
            panelImgHolder.BackColor = Color.LightBlue;
        }
        private void PlayerControl_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            
            if(this.IsFavorite)
                Cursor.Current = Cursors.PanNW;

            else
                Cursor.Current = Cursors.PanNE;
        }

        internal void UpdatePressedList()
        {
            switch (click)
            {
                case true:
                    if (!PressedPlayers.Contains(this))
                        PressedPlayers.Add(this);
                break;

                case false:
                    PressedPlayers.Remove(this);

                break;
            }
        }

        public int CompareTo(PlayerControl other)
            => ColumnContent2.CompareTo(other.ColumnContent2);

        public int Compare(PlayerControl other)
            => int.Parse(ColumnContent4).CompareTo(int.Parse(other.ColumnContent4));

        internal void ModifyForRanking()
        {
            panelImgHolder.Padding = new Padding(0);
            layoutPlayerControl.ColumnStyles[0].Width = 12.6F;
            layoutPlayerControl.ColumnStyles[1].Width = 29.4F;
            layoutPlayerControl.ColumnStyles[2].Width = 14;
            layoutPlayerControl.ColumnStyles[3].Width = 16;
            layoutPlayerControl.ColumnStyles[4].Width = 16;

            layoutPlayerControl.ColumnStyles[5].SizeType = SizeType.Percent;
            layoutPlayerControl.ColumnStyles[5].Width = 12;

            UpdateEvents(this);
                
            panelImgHolder.Padding = new Padding(3);
        }
        private void UpdateEvents(Control playerControl)
        {
            foreach (Control control in playerControl.Controls)
            {
                control.MouseUp -= PlayerControl_MouseUp;
                control.MouseDown -= PlayerControl_MouseDown;
                control.Click -= PlayerControl_Click;

                control.Click += PlayerControl_ClickFromRank;

                if (control.HasChildren)
                    UpdateEvents(control);
            }
        }
        private void PlayerControl_ClickFromRank(object sender, EventArgs e)
        {
            using(var Upload = new Dialogs.PhotoUpload(this))
            {
                Upload.ShowDialog();
            }
        }
    }
}
