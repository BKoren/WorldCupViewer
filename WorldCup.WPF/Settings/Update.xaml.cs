using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WorldCup.WPF.Windows;
using WorldCup.DataLayer;

namespace WorldCup.WPF.Settings
{
    public partial class Update : Base
    {
        public Update(WindowManager manager) : base(manager)
        {
            InitializeComponent();

            Button buttonApply = new Button
            {
                Name = "btnUpdateApply",
                Content = DataLayer.Resources.BtnApply,
                IsDefault = true,
                Style = (Style)FindResource("btn")
            };

            Button buttonBack = new Button
            {
                Name = "btnBack",
                Content = DataLayer.Resources.BtnBack,               
                IsCancel = true,
                Style = (Style)FindResource("btn")
            };

            BaseContent.UpdateBack.Children.Add(buttonBack);
            BaseContent.UpdateApply.Children.Add(buttonApply);
            buttonApply.Click += BtnApply_Click;
            buttonBack.Click += BtnBack_Click;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= Window_Closing;
         
            _manager.Next(new MainWindow(_manager));

            Close();
        }

        protected void BtnApply_Click(object sender, EventArgs e)
        {
            this.Closing -= Window_Closing;

            if (BaseContent.SelectedCategory != SettingsManager.Category)
            {
                SettingsManager.CategoryIsChanged = true;
                SettingsManager.RemoveFavorites();
            }
            else
                SettingsManager.CategoryIsChanged = false;
                       
            SettingsManager.Language = BaseContent.SelectedLanguage;
            SettingsManager.Category = BaseContent.SelectedCategory;
            SettingsManager.Screen = BaseContent.SelectedSize;
            SettingsManager.SaveSettings();

            _manager.Loading = true;
            _manager.Next(new MainWindow(_manager));

            Close();
        }
    }
}
