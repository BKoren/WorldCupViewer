using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCup.DataLayer;

namespace WorldCup.WPF.Dialogs
{
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();

            LanguageManager.ApplyLanguage();

            this.Activate();
            this.BringIntoView();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadingMessage.Text = DataLayer.Resources.TextLoading;
        }
    }
}
