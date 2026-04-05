using System.Windows.Forms;

namespace WorldCup.WinForms.Settings
{
    public partial class StartUp
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {               
                components?.Dispose();
            }
    
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUp));
            this.layoutOuter = new System.Windows.Forms.TableLayoutPanel();
            this.layoutInner = new System.Windows.Forms.TableLayoutPanel();
            this.labelDataLoad = new System.Windows.Forms.Label();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.layoutInnerBottom = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxJSON = new System.Windows.Forms.CheckBox();
            this.checkBoxAPI = new System.Windows.Forms.CheckBox();
            this.layoutIpper = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.layoutUpperInner = new System.Windows.Forms.TableLayoutPanel();
            this.labelIntroText = new System.Windows.Forms.Label();
            this.layoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.layoutOuter.SuspendLayout();
            this.layoutInner.SuspendLayout();
            this.layoutInnerBottom.SuspendLayout();
            this.layoutIpper.SuspendLayout();
            this.layoutUpperInner.SuspendLayout();
            this.layoutBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutOuter
            // 
            this.layoutOuter.ColumnCount = 1;
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutOuter.Controls.Add(this.layoutInner, 0, 1);
            this.layoutOuter.Controls.Add(this.layoutIpper, 0, 0);
            this.layoutOuter.Controls.Add(this.layoutBottom, 0, 2);
            this.layoutOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOuter.Location = new System.Drawing.Point(0, 0);
            this.layoutOuter.Name = "layoutOuter";
            this.layoutOuter.RowCount = 3;
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.layoutOuter.Size = new System.Drawing.Size(871, 534);
            this.layoutOuter.TabIndex = 0;
            // 
            // layoutInner
            // 
            this.layoutInner.ColumnCount = 1;
            this.layoutInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutInner.Controls.Add(this.labelDataLoad, 0, 4);
            this.layoutInner.Controls.Add(this.labelLanguage, 0, 0);
            this.layoutInner.Controls.Add(this.labelGender, 0, 2);
            this.layoutInner.Controls.Add(this.comboBoxCategory, 0, 3);
            this.layoutInner.Controls.Add(this.comboBoxLanguage, 0, 1);
            this.layoutInner.Controls.Add(this.layoutInnerBottom, 0, 5);
            this.layoutInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInner.Location = new System.Drawing.Point(3, 149);
            this.layoutInner.Name = "layoutInner";
            this.layoutInner.RowCount = 6;
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutInner.Size = new System.Drawing.Size(865, 314);
            this.layoutInner.TabIndex = 0;
            // 
            // labelDataLoad
            // 
            this.labelDataLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDataLoad.AutoSize = true;
            this.labelDataLoad.Location = new System.Drawing.Point(90, 184);
            this.labelDataLoad.Margin = new System.Windows.Forms.Padding(90, 50, 0, 0);
            this.labelDataLoad.Name = "labelDataLoad";
            this.labelDataLoad.Size = new System.Drawing.Size(18, 20);
            this.labelDataLoad.TabIndex = 7;
            this.labelDataLoad.Text = "?";
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(90, 10);
            this.labelLanguage.Margin = new System.Windows.Forms.Padding(90, 10, 0, 0);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(18, 20);
            this.labelLanguage.TabIndex = 5;
            this.labelLanguage.Text = "?";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(90, 77);
            this.labelGender.Margin = new System.Windows.Forms.Padding(90, 10, 0, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(18, 20);
            this.labelGender.TabIndex = 4;
            this.labelGender.Text = "?";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(75, 97);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(75, 0, 250, 0);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(540, 37);
            this.comboBoxCategory.TabIndex = 3;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategory_SelectedIndexChanged);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(75, 30);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(75, 0, 250, 0);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(540, 37);
            this.comboBoxLanguage.TabIndex = 2;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLanguage_SelectedIndexChanged);
            // 
            // layoutInnerBottom
            // 
            this.layoutInnerBottom.ColumnCount = 4;
            this.layoutInnerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutInnerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutInnerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutInnerBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutInnerBottom.Controls.Add(this.checkBoxJSON, 0, 0);
            this.layoutInnerBottom.Controls.Add(this.checkBoxAPI, 1, 0);
            this.layoutInnerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInnerBottom.Location = new System.Drawing.Point(3, 207);
            this.layoutInnerBottom.Name = "layoutInnerBottom";
            this.layoutInnerBottom.RowCount = 1;
            this.layoutInnerBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutInnerBottom.Size = new System.Drawing.Size(859, 104);
            this.layoutInnerBottom.TabIndex = 8;
            // 
            // checkBoxJSON
            // 
            this.checkBoxJSON.AutoSize = true;
            this.checkBoxJSON.Location = new System.Drawing.Point(75, 15);
            this.checkBoxJSON.Margin = new System.Windows.Forms.Padding(75, 15, 3, 3);
            this.checkBoxJSON.Name = "checkBoxJSON";
            this.checkBoxJSON.Size = new System.Drawing.Size(44, 24);
            this.checkBoxJSON.TabIndex = 0;
            this.checkBoxJSON.Text = "?";
            this.checkBoxJSON.UseVisualStyleBackColor = true;
            this.checkBoxJSON.CheckedChanged += new System.EventHandler(this.CheckBoxJSON_CheckedChanged);
            // 
            // checkBoxAPI
            // 
            this.checkBoxAPI.AutoSize = true;
            this.checkBoxAPI.Location = new System.Drawing.Point(217, 15);
            this.checkBoxAPI.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.checkBoxAPI.Name = "checkBoxAPI";
            this.checkBoxAPI.Size = new System.Drawing.Size(44, 24);
            this.checkBoxAPI.TabIndex = 1;
            this.checkBoxAPI.Text = "?";
            this.checkBoxAPI.UseVisualStyleBackColor = true;
            this.checkBoxAPI.CheckedChanged += new System.EventHandler(this.CheckBoxAPI_CheckedChanged);
            // 
            // layoutIpper
            // 
            this.layoutIpper.ColumnCount = 1;
            this.layoutIpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutIpper.Controls.Add(this.labelTitle, 0, 0);
            this.layoutIpper.Controls.Add(this.layoutUpperInner, 0, 1);
            this.layoutIpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutIpper.Location = new System.Drawing.Point(3, 3);
            this.layoutIpper.Name = "layoutIpper";
            this.layoutIpper.RowCount = 2;
            this.layoutIpper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutIpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutIpper.Size = new System.Drawing.Size(865, 140);
            this.layoutIpper.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(420, 10);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(24, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "?";
            // 
            // layoutUpperInner
            // 
            this.layoutUpperInner.ColumnCount = 3;
            this.layoutUpperInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutUpperInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutUpperInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutUpperInner.Controls.Add(this.labelIntroText, 1, 0);
            this.layoutUpperInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutUpperInner.Location = new System.Drawing.Point(3, 38);
            this.layoutUpperInner.Name = "layoutUpperInner";
            this.layoutUpperInner.RowCount = 1;
            this.layoutUpperInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutUpperInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.layoutUpperInner.Size = new System.Drawing.Size(859, 99);
            this.layoutUpperInner.TabIndex = 1;
            // 
            // labelIntroText
            // 
            this.labelIntroText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelIntroText.AutoSize = true;
            this.labelIntroText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIntroText.Location = new System.Drawing.Point(417, 54);
            this.labelIntroText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.labelIntroText.Name = "labelIntroText";
            this.labelIntroText.Size = new System.Drawing.Size(23, 25);
            this.labelIntroText.TabIndex = 2;
            this.labelIntroText.Text = "?";
            this.labelIntroText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layoutBottom
            // 
            this.layoutBottom.ColumnCount = 4;
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottom.Controls.Add(this.btnBack, 0, 0);
            this.layoutBottom.Controls.Add(this.btnNext, 3, 0);
            this.layoutBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutBottom.Location = new System.Drawing.Point(3, 469);
            this.layoutBottom.Name = "layoutBottom";
            this.layoutBottom.RowCount = 1;
            this.layoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottom.Size = new System.Drawing.Size(865, 62);
            this.layoutBottom.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Location = new System.Drawing.Point(40, 5);
            this.btnBack.Margin = new System.Windows.Forms.Padding(40, 5, 75, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 47);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "?";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Location = new System.Drawing.Point(723, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(75, 5, 40, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 47);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "?";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(871, 534);
            this.Controls.Add(this.layoutOuter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartUp";
            this.Opacity = 1D;
            this.Text = "";
            this.Load += new System.EventHandler(this.Initialization_Load);
            this.layoutOuter.ResumeLayout(false);
            this.layoutInner.ResumeLayout(false);
            this.layoutInner.PerformLayout();
            this.layoutInnerBottom.ResumeLayout(false);
            this.layoutInnerBottom.PerformLayout();
            this.layoutIpper.ResumeLayout(false);
            this.layoutIpper.PerformLayout();
            this.layoutUpperInner.ResumeLayout(false);
            this.layoutUpperInner.PerformLayout();
            this.layoutBottom.ResumeLayout(false);
            this.layoutBottom.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private TableLayoutPanel layoutInnerBottom;
        private TableLayoutPanel layoutUpperInner;
        private TableLayoutPanel layoutOuter;
        private TableLayoutPanel layoutInner;
        private TableLayoutPanel layoutIpper;
        private TableLayoutPanel layoutBottom;
        private ComboBox comboBoxCategory;
        private ComboBox comboBoxLanguage;
        private CheckBox checkBoxJSON;
        private CheckBox checkBoxAPI;
        private Button btnBack;
        private Button btnNext;
        private Label labelTitle;
        private Label labelIntroText;
        private Label labelGender;
        private Label labelDataLoad;
        private Label labelLanguage;
    }
}

