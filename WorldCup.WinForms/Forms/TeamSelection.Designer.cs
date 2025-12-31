using System.Windows.Forms;

namespace WorldCup.WinForms
{
    partial class TeamSelection
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                comboBoxTeamSelector.Items.Clear();

                this.Load -= TeamSelection_Load;
                this.btnNext.Click -= BtnNext_Click;

                foreach (Control control in this.Controls)
                {
                    control?.Dispose();
                }

                components?.Dispose();

            }            

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamSelection));
            this.layoutOuter = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.comboBoxTeamSelector = new System.Windows.Forms.ComboBox();
            this.layoutUpper = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelOption = new System.Windows.Forms.Label();
            this.layoutOuter.SuspendLayout();
            this.layoutUpper.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutOuter
            // 
            this.layoutOuter.AutoSize = true;
            this.layoutOuter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutOuter.BackColor = System.Drawing.SystemColors.Control;
            this.layoutOuter.ColumnCount = 3;
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutOuter.Controls.Add(this.btnNext, 1, 2);
            this.layoutOuter.Controls.Add(this.comboBoxTeamSelector, 1, 1);
            this.layoutOuter.Controls.Add(this.layoutUpper, 1, 0);
            this.layoutOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOuter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.layoutOuter.Location = new System.Drawing.Point(0, 0);
            this.layoutOuter.Name = "layoutOuter";
            this.layoutOuter.RowCount = 3;
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutOuter.Size = new System.Drawing.Size(800, 450);
            this.layoutOuter.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(380, 392);
            this.btnNext.Margin = new System.Windows.Forms.Padding(180, 10, 180, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 48);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "?";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // comboBoxTeamSelector
            // 
            this.comboBoxTeamSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTeamSelector.FormattingEnabled = true;
            this.comboBoxTeamSelector.Location = new System.Drawing.Point(203, 70);
            this.comboBoxTeamSelector.MaxDropDownItems = 1;
            this.comboBoxTeamSelector.Name = "comboBoxTeamSelector";
            this.comboBoxTeamSelector.Size = new System.Drawing.Size(394, 33);
            this.comboBoxTeamSelector.TabIndex = 2;
            this.comboBoxTeamSelector.SelectedIndexChanged += new System.EventHandler(this.TeamSelector_SelectedIndexChanged);
            // 
            // layoutUpper
            // 
            this.layoutUpper.ColumnCount = 1;
            this.layoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutUpper.Controls.Add(this.labelTitle, 0, 0);
            this.layoutUpper.Controls.Add(this.labelOption, 0, 1);
            this.layoutUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutUpper.Location = new System.Drawing.Point(203, 3);
            this.layoutUpper.Name = "layoutUpper";
            this.layoutUpper.RowCount = 2;
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutUpper.Size = new System.Drawing.Size(394, 61);
            this.layoutUpper.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(185, 2);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(23, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "?";
            // 
            // labelOption
            // 
            this.labelOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelOption.AutoSize = true;
            this.labelOption.Location = new System.Drawing.Point(185, 36);
            this.labelOption.Name = "labelOption";
            this.labelOption.Size = new System.Drawing.Size(23, 25);
            this.labelOption.TabIndex = 1;
            this.labelOption.Text = "?";
            // 
            // TeamSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeamSelection";
            this.Opacity = 0D;
            this.Text = "";
            this.Load += new System.EventHandler(this.TeamSelection_Load);
            this.layoutOuter.ResumeLayout(false);
            this.layoutUpper.ResumeLayout(false);
            this.layoutUpper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private TableLayoutPanel layoutOuter;
        private TableLayoutPanel layoutUpper;
        private ComboBox comboBoxTeamSelector;
        private Button btnNext;
        private Label labelOption;
        private Label labelTitle;
    }
}