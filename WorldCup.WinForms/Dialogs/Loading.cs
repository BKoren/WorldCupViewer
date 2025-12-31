using System;
using System.Drawing;
using System.Windows.Forms;
using WorldCup.DataLayer;

namespace WorldCup.WinForms.Dialogs
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();

            LanguageManager.ApplyLanguage();

            this.Activate();
            this.BringToFront();
            this.Icon = WinForms.Properties.Resources.FormFavicon;
            this.Size = new Size(400, 250);
            this.BackColor = Color.White;            
            this.MaximizeBox = false;            
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            labelLoading.Text = Resources.TextLoading;
        }
    }
}
