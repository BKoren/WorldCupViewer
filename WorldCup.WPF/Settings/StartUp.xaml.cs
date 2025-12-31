using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using WorldCup.WPF.Windows;
using WorldCup.DataLayer;
using System.ComponentModel;

namespace WorldCup.WPF.Settings
{
    public partial class StartUp : Base
    {
        public StartUp(WindowManager manager) : base(manager) 
        { 
            InitializeComponent();

            Button buttonApply = new Button
            {
                Name = "buttonStartUpApply",
                Content = DataLayer.Resources.BtnApply,
                IsDefault = true,
                Style = (Style)FindResource("btn")
            };

            BaseContent.StartUpApply.Children.Add(buttonApply);
            buttonApply.Click += BtnApply_Click;
        }

        protected override void Window_Closing(object sender, CancelEventArgs e)
        {
            base.Window_Closing(sender, e);

            Application.Current.Shutdown();
        }

        protected void BtnApply_Click(object sender, EventArgs e)
        {
            this.Closing -= Window_Closing;

            SettingsManager.Language = BaseContent.SelectedLanguage;
            if (BaseContent.SelectedCategory != SettingsManager.Category)
            {
                SettingsManager.CategoryIsChanged = true;
                SettingsManager.RemoveFavorites();
            }
            else
                SettingsManager.CategoryIsChanged = false;

            SettingsManager.Category = BaseContent.SelectedCategory;
            SettingsManager.Screen = BaseContent.SelectedSize;
            SettingsManager.SaveSettings();

            _manager.Loading = true;
            _manager.Next(new MainWindow(_manager));

            Close();
        }
    }
}

    
