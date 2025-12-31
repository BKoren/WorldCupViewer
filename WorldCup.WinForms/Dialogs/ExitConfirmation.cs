using System;
using System.Drawing;
using System.Windows.Forms;
using WorldCup.DataLayer;

namespace WorldCup.WinForms.Dialogs
{
    public partial class ExitConfirmation : Form
    {
        public bool Confirmed { get; set; } = false;

        public ExitConfirmation()
        {
            InitializeComponent();

            this.Text = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
            this.ClientSize = new Size(240, 120);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.CancelButton = btnNo;
            this.AcceptButton = btnYes;
            this.ActiveControl = btnYes;

            btnYes.Text = Resources.BtnYes;
            btnNo.Text = Resources.BtnNo;
            labelMessage.Text = Resources.TextExit;
        }

        private void ConfirmationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnYes.PerformClick();
            
            else if (e.KeyCode == Keys.Escape)
                btnNo.PerformClick();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            Confirmed = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {        
            Confirmed = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
