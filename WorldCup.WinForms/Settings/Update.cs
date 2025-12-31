using System;
using System.IO;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Models;

namespace WorldCup.WinForms.Settings
{
    public partial class Update : StartUp
    {
        public Update(FormManager manager) : base(manager)
        {
            InitializeComponent();
        }
        private void InitializationUpdate_Load(object sender, EventArgs e)
        {
            base.Modification();
        }

        protected override void BtnNext_Click(object sender, EventArgs e)
        {
            if (category != SettingsManager.Category)
            {
                SettingsManager.CategoryIsChanged = true;
                SettingsManager.RemoveFavorites();
            }
            else
                SettingsManager.CategoryIsChanged = false;

            base.BtnNext_Click(sender, e);
        }
        protected override void BtnBack_Click(object sender, EventArgs e)
        {
            _manager.TransitionNext(new PlayerSelection(_manager));
        }        
    }
}
