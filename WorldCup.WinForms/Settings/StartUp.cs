using System;
using WorldCup.DataLayer;

namespace WorldCup.WinForms.Settings
{
    public partial class StartUp : Base
    {
        public StartUp(FormManager manager) : base(manager)
        {
            InitializeComponent();
            SetType(Type.Small);

            this.CancelButton = btnBack;
            this.AcceptButton = btnNext;

            if (!DataLayer.Settings.Base.InitializationCheck())
                SettingsManager.InitializeSettings();
        }

        private void Initialization_Load(object sender, EventArgs e)
        {
            labelTitle.Text = Resources.Title;
            labelTitle.Font = TitleFont;

            labelIntroText.Text = Resources.TextIntro;
            labelLanguage.Text = Resources.TextOptionLanguage;
            labelGender.Text = Resources.TextOptionCategory;
            labelDataLoad.Text = Resources.TextDataLoad;

            labelIntroText.Font = TextFont;
            labelLanguage.Font = TextFont;
            labelGender.Font = TextFont;

            checkBoxAPI.Text = Resources.TextOptionAPI;
            checkBoxJSON.Text = Resources.TextOptionJSON;
            checkBoxAPI.Checked = true;

            btnNext.Text = Resources.BtnNext;
            btnBack.Text = Resources.BtnBack;

            btnBack.Visible = false;
            btnBack.Enabled = false;

            comboBoxLanguage.Items.Add(Resources.TextLanguageENG);
            comboBoxLanguage.Items.Add(Resources.TextLanguageHRV);
            comboBoxCategory.Items.Add(Resources.TextCategoryMale);
            comboBoxCategory.Items.Add(Resources.TextCategoryFemale);

            comboBoxLanguage.SelectedIndex = 0;
            comboBoxCategory.SelectedIndex = 0;
        }

        protected string language = string.Empty;
        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            language = LanguageManager.GetCompilerCode(
                comboBoxLanguage.Items[comboBoxLanguage.SelectedIndex]
                .ToString()
            );          
        }

        protected string category = string.Empty;
        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {                       
            category = CategoryManager.GetCompilerCode(
                comboBoxCategory.Items[comboBoxCategory.SelectedIndex]
                .ToString()
            );           
        }

        protected string loadMethod = string.Empty;
        private void CheckBoxAPI_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAPI.Checked && !checkBoxJSON.Checked)
                checkBoxJSON.Checked = true;

            else if (checkBoxAPI.Checked)
                checkBoxJSON.Checked = false;

            loadMethod = "API";
        }
        private void CheckBoxJSON_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAPI.Checked && !checkBoxJSON.Checked)
                checkBoxAPI.Checked = true;

            else if (checkBoxJSON.Checked)
                checkBoxAPI.Checked = false;

            loadMethod = "JSON";
        }

        protected virtual void BtnNext_Click(object sender, EventArgs e)
        {            
            SettingsManager.Language = language;
            SettingsManager.Category = category;
            SettingsManager.LoadMethod = loadMethod;
            SettingsManager.SaveSettings();

            _manager.Loading = true;
            _manager.TransitionNext(new TeamSelection(_manager));

            this.Dispose();
        }
        protected virtual void BtnBack_Click(object sender, EventArgs e) { }
        protected void Modification()
        {
            btnNext.Text = Resources.BtnApply;

            btnBack.Visible = true;
            btnBack.Enabled = true;
        }
    }
}
