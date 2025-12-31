using System;
using System.ComponentModel;
using System.Windows;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Exceptions;
using WorldCup.WPF.Dialogs;

namespace WorldCup.WPF.Windows
{
    public class Base : Window
    {
        protected readonly WindowManager _manager;

        public Base(WindowManager manager) 
        {
            _manager = manager;

            if (!DataLayer.Settings.Base.InitializationCheck())
                SettingsManager.InitializeSettings();
            
            if (SettingsManager.LoadMethod == null)
                SettingsManager.LoadMethod = "API";            

            LanguageManager.ApplyLanguage();

            this.Closing += Window_Closing;
        }

        protected virtual void Window_Closing(object sender, CancelEventArgs e)
        {
            ExitConfirmation exit = new ExitConfirmation();

            exit.Owner = this;
            exit.ShowDialog();

            if (!exit.Confirmed)
                e.Cancel = true;
        }

        internal static bool AbortWindow = false;
        public virtual void BeforeShow()
        {
            if (!AbortWindow)
                this.Show();

            else
                AbortWindow = false;
        }

        protected virtual void DisplayErrorMessage(Exception error)
        {
            string AdditionalInfo =
                ExceptionProcessor.ProcessException(error);

            MessageBox.Show(
                $"Error while loading form!\n" +
                $"{error.Message}" +
                 AdditionalInfo,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}
