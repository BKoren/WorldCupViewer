using System;
using System.Windows;
using System.Windows.Controls;
using WorldCup.DataLayer;

namespace WorldCup.WPF.Settings
{
    public partial class BaseContent : UserControl
    {      
        public BaseContent()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            title.Text = DataLayer.Resources.TextSettingsTitle;
            labelScreenText.Text = DataLayer.Resources.TextOptionScreenSize;
            labelLanguageText.Text = DataLayer.Resources.TextOptionLanguage;
            labelCategoryText.Text = DataLayer.Resources.TextOptionCategory;

            comboBoxScreen.Items.Add(DataLayer.Resources.TextScreenFull);
            comboBoxScreen.Items.Add(DataLayer.Resources.TextScreenMedium);
            comboBoxScreen.Items.Add(DataLayer.Resources.TextScreenSmall);

            comboBoxLanguage.Items.Add(DataLayer.Resources.TextLanguageENG);
            comboBoxLanguage.Items.Add(DataLayer.Resources.TextLanguageHRV);

            comboBoxCategory.Items.Add(DataLayer.Resources.TextCategoryMale);
            comboBoxCategory.Items.Add(DataLayer.Resources.TextCategoryFemale);

            comboBoxScreen.SelectedIndex = 0;
            comboBoxLanguage.SelectedIndex = 0;
            comboBoxCategory.SelectedIndex = 0;
        }       

        public string SelectedSize { get => size; }
        public string SelectedLanguage { get => language; }
        public string SelectedCategory { get => category; }

        private string size = string.Empty;
        private void ScreenOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (comboBoxScreen.SelectedIndex)
            {
                case 0:
                    size = "Full";
                    break;

                case 1:
                    size = "Medium";
                    break;

                case 2:
                    size = "Small";
                    break;
            }
        }

        private string language = string.Empty;
        private void LanguageOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            language = LanguageManager.GetCompilerCode(
                comboBoxLanguage.Items[comboBoxLanguage.SelectedIndex]
                .ToString()
            );
        }

        private string category = string.Empty;
        private void CategoryOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            category = CategoryManager.GetCompilerCode(
                comboBoxCategory.Items[comboBoxCategory.SelectedIndex]
                .ToString()
            );
        }

        private Button BtnStartUpApply, BtnUpdateApply, BtnBack;
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            header.Height = this.ActualHeight * 0.1;
            header.Width = this.ActualWidth * 0.7;

            content.Height = this.ActualHeight * 0.70;
            content.Width = this.ActualWidth * 0.70;

            footer.Height = this.ActualHeight * 0.1;
            footer.Width = this.ActualWidth * 0.8; 

            if(!SettingsManager.CheckForSettings(false) || SettingsManager.StartUpIsNessecary)
            {
                StartUpApplyPosition.Visibility = Visibility.Visible;
                UpdateApplyPosition.Visibility = Visibility.Collapsed;
                UpdateBackPosition.Visibility = Visibility.Collapsed;

                BtnStartUpApply = StartUpApply?.Children[0] as Button;
                BtnStartUpApply.Height = this.ActualHeight * 0.1;
                BtnStartUpApply.Width = this.ActualWidth * 0.125;
            }

            else
            {
                StartUpApplyPosition.Visibility = Visibility.Collapsed;
                UpdateApplyPosition.Visibility = Visibility.Visible;
                UpdateBackPosition.Visibility = Visibility.Visible;

                BtnUpdateApply = UpdateApply?.Children[0] as Button;
                BtnUpdateApply.Height = this.ActualHeight * 0.1;
                BtnUpdateApply.Width = this.ActualWidth * 0.125;

                BtnBack = UpdateBack?.Children[0] as Button;
                BtnBack.Height = this.ActualHeight * 0.1;
                BtnBack.Width = this.ActualWidth * 0.125;
            }

            Resources["ComboBoxItemFontSize"] = Math.Min(this.ActualWidth, this.ActualHeight) * 0.05;
            Resources["btnFontSize"] = Math.Min(this.ActualHeight, this.ActualWidth) * 0.035;
        }
    }
}

