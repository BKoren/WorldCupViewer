using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Exceptions;

namespace WorldCup.WinForms
{
    public partial class Base : Form
    {
        protected readonly FormManager _manager;
        public Base()
        {
            InitializeComponent();
        }
        public Base(FormManager manager)
        {
            _manager = manager;

            this.Text = "";
            this.Opacity = 0;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            if (DataLayer.Settings.Base.InitializationCheck())
                LanguageManager.ApplyLanguage();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new string Text
        {
            get => base.Text; 
            set => base.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new double Opacity
        {
            get => base.Opacity;
            set => base.Opacity = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool MaximizeBox
        {
            get => base.MaximizeBox;
            set => base.MaximizeBox = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new FormBorderStyle FormBorderStyle
        {
            get => base.FormBorderStyle;
            set => base.FormBorderStyle = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new FormStartPosition StartPosition
        {
            get => base.StartPosition;
            set => base.StartPosition = value;
        }

        private Type size;
        protected enum Type
        {
            Small,
            Regular
        }
        protected void SetType(Type type)
            => this.size = type;

        protected Font TitleFont = 
            new Font(new FontFamily("Arial"), 10, System.Drawing.FontStyle.Bold);

        protected Font TextFontBig =
            new Font(new FontFamily("Segoe Print"), 12, System.Drawing.FontStyle.Regular);

        protected Font TextFont =
            new Font(new FontFamily("Segoe Print"), 10, System.Drawing.FontStyle.Regular);

        protected Font TextFontSmall =
            new Font(new FontFamily("Segoe Print"), 8, System.Drawing.FontStyle.Regular);

        protected virtual void DisplayErrorMessage(Exception error)
        {
            string AdditionalInfo =
                ExceptionProcessor.ProcessException(error);

            MessageBox.Show(
                $"Error while loading form!\n" +
                $"{error.Message}" +
                 AdditionalInfo,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        private void FormBase_FormLoad(object sender, EventArgs e)
        {
            this.Text = "";
            this.Icon = WinForms.Properties.Resources.FormFavicon;

            this.BackgroundImage = WinForms.Properties.Resources.FormBackground;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            FormClosing += FormBase_FormClosing;
            
            switch(size)
            {
                case Type.Small:
                    this.Width = 587;
                    this.Height = 386;
                break;

                case Type.Regular:
                    this.Width = 720;
                    this.Height = 500;
                break;
            }

            foreach (var control in this.Controls)
            {
                if (control is Panel panel)                
                    panel.BackColor = Color.Transparent;
            }
        }
        protected virtual void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var ExitForm = new Dialogs.ExitConfirmation())
            {
                if (ExitForm.ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true; 
                }
            }
        }
        
        public virtual void ShowAsync()
        {
            if (!_manager.AbortForm)
                this.Show();

            else
                _manager.AbortForm = false;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Activate();
            this.BringToFront();

            this.Opacity = 1;
        }
    }
}
