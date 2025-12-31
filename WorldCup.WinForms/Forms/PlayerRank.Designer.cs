using System.Windows.Forms;
using WorldCup.WinForms.Dialogs;

namespace WorldCup.WinForms
{
    partial class PlayerRank
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            PhotoUpload.RefreshForm -= ActivatorRefresh;
            PhotoUpload.RemoveImg -= ActivatorRemoval;

            if (disposing && (components != null))
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRank));
            this.layoutOuter = new System.Windows.Forms.TableLayoutPanel();
            this.layoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.labelSetImageOption = new System.Windows.Forms.Label();
            this.layoutUpper = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.layoutBottomUpper = new System.Windows.Forms.TableLayoutPanel();
            this.btnRankCard = new System.Windows.Forms.Button();
            this.btnRankGoal = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnMatches = new System.Windows.Forms.Button();
            this.layoutInnerUpper = new System.Windows.Forms.TableLayoutPanel();
            this.labelRankOption = new System.Windows.Forms.Label();
            this.labelCategoryOption = new System.Windows.Forms.Label();
            this.layoutRankMarks = new System.Windows.Forms.TableLayoutPanel();
            this.labelMark1 = new System.Windows.Forms.Label();
            this.labelMark2 = new System.Windows.Forms.Label();
            this.labelMark3 = new System.Windows.Forms.Label();
            this.labelMark4 = new System.Windows.Forms.Label();
            this.labelMark5 = new System.Windows.Forms.Label();
            this.panelControlRanking = new System.Windows.Forms.Panel();
            this.layoutOuter.SuspendLayout();
            this.layoutBottom.SuspendLayout();
            this.layoutUpper.SuspendLayout();
            this.layoutBottomUpper.SuspendLayout();
            this.layoutInnerUpper.SuspendLayout();
            this.layoutRankMarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutOuter
            // 
            this.layoutOuter.ColumnCount = 1;
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutOuter.Controls.Add(this.layoutBottom, 0, 2);
            this.layoutOuter.Controls.Add(this.layoutUpper, 0, 0);
            this.layoutOuter.Controls.Add(this.panelControlRanking, 0, 1);
            this.layoutOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOuter.Location = new System.Drawing.Point(0, 0);
            this.layoutOuter.Name = "layoutOuter";
            this.layoutOuter.RowCount = 3;
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutOuter.Size = new System.Drawing.Size(800, 450);
            this.layoutOuter.TabIndex = 0;
            // 
            // layoutBottom
            // 
            this.layoutBottom.ColumnCount = 3;
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutBottom.Controls.Add(this.btnPrint, 1, 0);
            this.layoutBottom.Controls.Add(this.btnBack, 0, 0);
            this.layoutBottom.Controls.Add(this.labelSetImageOption, 2, 0);
            this.layoutBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutBottom.Location = new System.Drawing.Point(3, 407);
            this.layoutBottom.Name = "layoutBottom";
            this.layoutBottom.RowCount = 1;
            this.layoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottom.Size = new System.Drawing.Size(794, 40);
            this.layoutBottom.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrint.Location = new System.Drawing.Point(198, 0);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0, 0, 40, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(158, 30);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "?";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Location = new System.Drawing.Point(40, 10);
            this.btnBack.Margin = new System.Windows.Forms.Padding(40, 10, 80, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 20);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "?";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // labelSetImageOption
            // 
            this.labelSetImageOption.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSetImageOption.AutoSize = true;
            this.labelSetImageOption.Location = new System.Drawing.Point(396, 5);
            this.labelSetImageOption.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.labelSetImageOption.Name = "labelSetImageOption";
            this.labelSetImageOption.Size = new System.Drawing.Size(27, 20);
            this.labelSetImageOption.TabIndex = 3;
            this.labelSetImageOption.Text = "??";
            this.labelSetImageOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layoutUpper
            // 
            this.layoutUpper.AutoScroll = true;
            this.layoutUpper.AutoSize = true;
            this.layoutUpper.ColumnCount = 1;
            this.layoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutUpper.Controls.Add(this.labelTitle, 0, 0);
            this.layoutUpper.Controls.Add(this.layoutBottomUpper, 0, 2);
            this.layoutUpper.Controls.Add(this.layoutInnerUpper, 0, 1);
            this.layoutUpper.Controls.Add(this.layoutRankMarks, 0, 3);
            this.layoutUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutUpper.Location = new System.Drawing.Point(0, 0);
            this.layoutUpper.Margin = new System.Windows.Forms.Padding(0);
            this.layoutUpper.Name = "layoutUpper";
            this.layoutUpper.RowCount = 4;
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutUpper.Size = new System.Drawing.Size(800, 112);
            this.layoutUpper.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(391, 10);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(18, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "?";
            // 
            // layoutBottomUpper
            // 
            this.layoutBottomUpper.ColumnCount = 4;
            this.layoutBottomUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottomUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottomUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottomUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutBottomUpper.Controls.Add(this.btnRankCard, 3, 0);
            this.layoutBottomUpper.Controls.Add(this.btnRankGoal, 2, 0);
            this.layoutBottomUpper.Controls.Add(this.btnPlayers, 1, 0);
            this.layoutBottomUpper.Controls.Add(this.btnMatches, 0, 0);
            this.layoutBottomUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutBottomUpper.Location = new System.Drawing.Point(25, 55);
            this.layoutBottomUpper.Margin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.layoutBottomUpper.Name = "layoutBottomUpper";
            this.layoutBottomUpper.RowCount = 1;
            this.layoutBottomUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottomUpper.Size = new System.Drawing.Size(750, 39);
            this.layoutBottomUpper.TabIndex = 1;
            // 
            // btnRankCard
            // 
            this.btnRankCard.AutoSize = true;
            this.btnRankCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRankCard.Location = new System.Drawing.Point(566, 8);
            this.btnRankCard.Margin = new System.Windows.Forms.Padding(5, 8, 100, 5);
            this.btnRankCard.Name = "btnRankCard";
            this.btnRankCard.Size = new System.Drawing.Size(84, 26);
            this.btnRankCard.TabIndex = 0;
            this.btnRankCard.Text = "??";
            this.btnRankCard.UseVisualStyleBackColor = true;
            this.btnRankCard.Click += new System.EventHandler(this.BtnRankCard_Click);
            // 
            // btnRankGoal
            // 
            this.btnRankGoal.AutoSize = true;
            this.btnRankGoal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRankGoal.Location = new System.Drawing.Point(474, 8);
            this.btnRankGoal.Margin = new System.Windows.Forms.Padding(100, 8, 5, 5);
            this.btnRankGoal.Name = "btnRankGoal";
            this.btnRankGoal.Size = new System.Drawing.Size(82, 26);
            this.btnRankGoal.TabIndex = 1;
            this.btnRankGoal.Text = "??";
            this.btnRankGoal.UseVisualStyleBackColor = true;
            this.btnRankGoal.Click += new System.EventHandler(this.BtnRankGoal_Click);
            // 
            // btnPlayers
            // 
            this.btnPlayers.AutoSize = true;
            this.btnPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlayers.Location = new System.Drawing.Point(192, 8);
            this.btnPlayers.Margin = new System.Windows.Forms.Padding(5, 8, 40, 2);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(142, 29);
            this.btnPlayers.TabIndex = 2;
            this.btnPlayers.Text = "??";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.BtnPlayers_Click);
            // 
            // btnMatches
            // 
            this.btnMatches.AutoSize = true;
            this.btnMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMatches.Location = new System.Drawing.Point(40, 8);
            this.btnMatches.Margin = new System.Windows.Forms.Padding(40, 8, 5, 2);
            this.btnMatches.Name = "btnMatches";
            this.btnMatches.Size = new System.Drawing.Size(142, 29);
            this.btnMatches.TabIndex = 3;
            this.btnMatches.Text = "??";
            this.btnMatches.UseVisualStyleBackColor = true;
            this.btnMatches.Click += new System.EventHandler(this.BtnMatches_Click);
            // 
            // layoutInnerUpper
            // 
            this.layoutInnerUpper.AutoSize = true;
            this.layoutInnerUpper.ColumnCount = 2;
            this.layoutInnerUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutInnerUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutInnerUpper.Controls.Add(this.labelRankOption, 1, 0);
            this.layoutInnerUpper.Controls.Add(this.labelCategoryOption, 0, 0);
            this.layoutInnerUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInnerUpper.Location = new System.Drawing.Point(25, 33);
            this.layoutInnerUpper.Margin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.layoutInnerUpper.Name = "layoutInnerUpper";
            this.layoutInnerUpper.RowCount = 1;
            this.layoutInnerUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutInnerUpper.Size = new System.Drawing.Size(750, 22);
            this.layoutInnerUpper.TabIndex = 2;
            // 
            // labelRankOption
            // 
            this.labelRankOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelRankOption.AutoSize = true;
            this.labelRankOption.Location = new System.Drawing.Point(549, 2);
            this.labelRankOption.Margin = new System.Windows.Forms.Padding(0);
            this.labelRankOption.Name = "labelRankOption";
            this.labelRankOption.Size = new System.Drawing.Size(27, 20);
            this.labelRankOption.TabIndex = 3;
            this.labelRankOption.Text = "??";
            // 
            // labelCategoryOption
            // 
            this.labelCategoryOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelCategoryOption.AutoSize = true;
            this.labelCategoryOption.Location = new System.Drawing.Point(174, 2);
            this.labelCategoryOption.Margin = new System.Windows.Forms.Padding(0);
            this.labelCategoryOption.Name = "labelCategoryOption";
            this.labelCategoryOption.Size = new System.Drawing.Size(27, 20);
            this.labelCategoryOption.TabIndex = 4;
            this.labelCategoryOption.Text = "??";
            // 
            // layoutRankMarks
            // 
            this.layoutRankMarks.BackColor = System.Drawing.Color.White;
            this.layoutRankMarks.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.layoutRankMarks.ColumnCount = 7;
            this.layoutRankMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.layoutRankMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.3F));
            this.layoutRankMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutRankMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutRankMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutRankMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.layoutRankMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.7F));
            this.layoutRankMarks.Controls.Add(this.labelMark1, 0, 0);
            this.layoutRankMarks.Controls.Add(this.labelMark2, 1, 0);
            this.layoutRankMarks.Controls.Add(this.labelMark3, 2, 0);
            this.layoutRankMarks.Controls.Add(this.labelMark4, 3, 0);
            this.layoutRankMarks.Controls.Add(this.labelMark5, 4, 0);
            this.layoutRankMarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRankMarks.Location = new System.Drawing.Point(25, 95);
            this.layoutRankMarks.Margin = new System.Windows.Forms.Padding(25, 1, 25, 0);
            this.layoutRankMarks.Name = "layoutRankMarks";
            this.layoutRankMarks.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.layoutRankMarks.RowCount = 1;
            this.layoutRankMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRankMarks.Size = new System.Drawing.Size(750, 17);
            this.layoutRankMarks.TabIndex = 3;
            // 
            // labelMark1
            // 
            this.labelMark1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMark1.AutoSize = true;
            this.labelMark1.Location = new System.Drawing.Point(34, 2);
            this.labelMark1.Margin = new System.Windows.Forms.Padding(0);
            this.labelMark1.Name = "labelMark1";
            this.labelMark1.Size = new System.Drawing.Size(27, 13);
            this.labelMark1.TabIndex = 0;
            this.labelMark1.Text = "??";
            // 
            // labelMark2
            // 
            this.labelMark2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMark2.AutoSize = true;
            this.labelMark2.Location = new System.Drawing.Point(185, 2);
            this.labelMark2.Margin = new System.Windows.Forms.Padding(0);
            this.labelMark2.Name = "labelMark2";
            this.labelMark2.Size = new System.Drawing.Size(27, 13);
            this.labelMark2.TabIndex = 1;
            this.labelMark2.Text = "??";
            // 
            // labelMark3
            // 
            this.labelMark3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMark3.AutoSize = true;
            this.labelMark3.Location = new System.Drawing.Point(345, 2);
            this.labelMark3.Margin = new System.Windows.Forms.Padding(0);
            this.labelMark3.Name = "labelMark3";
            this.labelMark3.Size = new System.Drawing.Size(27, 13);
            this.labelMark3.TabIndex = 2;
            this.labelMark3.Text = "??";
            // 
            // labelMark4
            // 
            this.labelMark4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMark4.AutoSize = true;
            this.labelMark4.Location = new System.Drawing.Point(456, 2);
            this.labelMark4.Margin = new System.Windows.Forms.Padding(0);
            this.labelMark4.Name = "labelMark4";
            this.labelMark4.Size = new System.Drawing.Size(27, 13);
            this.labelMark4.TabIndex = 3;
            this.labelMark4.Text = "??";
            // 
            // labelMark5
            // 
            this.labelMark5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMark5.AutoSize = true;
            this.labelMark5.Location = new System.Drawing.Point(567, 2);
            this.labelMark5.Margin = new System.Windows.Forms.Padding(0);
            this.labelMark5.Name = "labelMark5";
            this.labelMark5.Size = new System.Drawing.Size(27, 13);
            this.labelMark5.TabIndex = 4;
            this.labelMark5.Text = "??";
            // 
            // panelControlRanking
            // 
            this.panelControlRanking.AutoScroll = true;
            this.panelControlRanking.BackColor = System.Drawing.Color.White;
            this.panelControlRanking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelControlRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlRanking.Location = new System.Drawing.Point(25, 112);
            this.panelControlRanking.Margin = new System.Windows.Forms.Padding(25, 0, 25, 13);
            this.panelControlRanking.Name = "panelControlRanking";
            this.panelControlRanking.Size = new System.Drawing.Size(750, 279);
            this.panelControlRanking.TabIndex = 2;
            // 
            // PlayerRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutOuter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayerRank";
            this.Opacity = 1D;
            this.Text = "";
            this.Load += new System.EventHandler(this.PlayerRank_Load);
            this.layoutOuter.ResumeLayout(false);
            this.layoutOuter.PerformLayout();
            this.layoutBottom.ResumeLayout(false);
            this.layoutBottom.PerformLayout();
            this.layoutUpper.ResumeLayout(false);
            this.layoutUpper.PerformLayout();
            this.layoutBottomUpper.ResumeLayout(false);
            this.layoutBottomUpper.PerformLayout();
            this.layoutInnerUpper.ResumeLayout(false);
            this.layoutInnerUpper.PerformLayout();
            this.layoutRankMarks.ResumeLayout(false);
            this.layoutRankMarks.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private TableLayoutPanel layoutBottomUpper;
        private TableLayoutPanel layoutInnerUpper;
        private TableLayoutPanel layoutRankMarks;
        private TableLayoutPanel layoutBottom;
        private TableLayoutPanel layoutOuter;
        private TableLayoutPanel layoutUpper;
        private Button btnRankCard;
        private Button btnRankGoal;
        private Button btnPlayers;
        private Button btnMatches;
        private Button btnPrint;
        private Button btnBack;
        private Panel panelControlRanking;
        private Label labelSetImageOption;
        private Label labelCategoryOption;
        private Label labelRankOption;
        private Label labelFavoriteTeam;
        private Label labelTitle;
        private Label labelMark1;
        private Label labelMark2;
        private Label labelMark3;
        private Label labelMark4;
        private Label labelMark5;
    }
}