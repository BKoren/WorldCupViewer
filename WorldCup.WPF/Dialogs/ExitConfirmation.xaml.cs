using System;
using System.Windows;
using System.Windows.Input;

namespace WorldCup.WPF.Dialogs
{
    public partial class ExitConfirmation : Window
    {
        public bool Confirmed { get; set; }
        public ExitConfirmation()
        {
            Confirmed = false;
            InitializeComponent();
            
            this.btnYes.Focus();
            this.KeyDown += ExitConfirmation_KeyDown;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            exitMessage.Text = DataLayer.Resources.TextExit;
            btnNo.Content = DataLayer.Resources.BtnNo;
            btnYes.Content = DataLayer.Resources.BtnYes;
        }

        private void ExitConfirmation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Confirmed = true;
            if (e.Key == Key.Escape) Confirmed = false;

            this.Close();
        }     

        private void BtnNo_Click(object sender, EventArgs e)
        {
            Confirmed = false;
            Close();
        }
        private void BtnYes_Click(object sender, EventArgs e)
        {
            Confirmed = true;
            Close();
        }
    }
}
