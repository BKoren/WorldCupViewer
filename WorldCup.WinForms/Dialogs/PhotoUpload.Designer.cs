using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldCup.WinForms.Dialogs
{
    partial class PhotoUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoUpload));
            this.layoutOuter = new System.Windows.Forms.TableLayoutPanel();
            this.layoutMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.layoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.labelFormatOption = new System.Windows.Forms.Label();
            this.pictureBoxUploadedImg = new System.Windows.Forms.PictureBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.layoutOuter.SuspendLayout();
            this.layoutMiddle.SuspendLayout();
            this.layoutBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadedImg)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutOuter
            // 
            this.layoutOuter.ColumnCount = 1;
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutOuter.Controls.Add(this.layoutMiddle, 0, 2);
            this.layoutOuter.Controls.Add(this.labelPlayerName, 0, 1);
            this.layoutOuter.Controls.Add(this.layoutBottom, 0, 3);
            this.layoutOuter.Controls.Add(this.pictureBoxUploadedImg, 0, 0);
            this.layoutOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOuter.Location = new System.Drawing.Point(0, 0);
            this.layoutOuter.Margin = new System.Windows.Forms.Padding(0);
            this.layoutOuter.Name = "layoutOuter";
            this.layoutOuter.RowCount = 4;
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.layoutOuter.Size = new System.Drawing.Size(603, 544);
            this.layoutOuter.TabIndex = 0;
            // 
            // layoutMiddle
            // 
            this.layoutMiddle.ColumnCount = 3;
            this.layoutMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.layoutMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutMiddle.Controls.Add(this.btnApply, 2, 0);
            this.layoutMiddle.Controls.Add(this.btnUpload, 1, 0);
            this.layoutMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMiddle.Location = new System.Drawing.Point(0, 434);
            this.layoutMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMiddle.Name = "layoutMiddle";
            this.layoutMiddle.RowCount = 1;
            this.layoutMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMiddle.Size = new System.Drawing.Size(603, 81);
            this.layoutMiddle.TabIndex = 2;
            // 
            // btnUpload
            // 
            this.btnUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpload.Location = new System.Drawing.Point(240, 15);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(40, 15, 40, 15);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(121, 51);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "??";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(288, 380);
            this.labelPlayerName.Margin = new System.Windows.Forms.Padding(0);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(27, 20);
            this.labelPlayerName.TabIndex = 1;
            this.labelPlayerName.Text = "??";
            // 
            // layoutBottom
            // 
            this.layoutBottom.ColumnCount = 3;
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutBottom.Controls.Add(this.labelFormatOption, 1, 0);
            this.layoutBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutBottom.Location = new System.Drawing.Point(0, 515);
            this.layoutBottom.Margin = new System.Windows.Forms.Padding(0);
            this.layoutBottom.Name = "layoutBottom";
            this.layoutBottom.RowCount = 1;
            this.layoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottom.Size = new System.Drawing.Size(603, 29);
            this.layoutBottom.TabIndex = 0;
            // 
            // labelFormatOption
            // 
            this.labelFormatOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFormatOption.AutoSize = true;
            this.labelFormatOption.Location = new System.Drawing.Point(287, 0);
            this.labelFormatOption.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.labelFormatOption.Name = "labelFormatOption";
            this.labelFormatOption.Size = new System.Drawing.Size(27, 19);
            this.labelFormatOption.TabIndex = 0;
            this.labelFormatOption.Text = "??";
            // 
            // pictureBoxUploadedImg
            // 
            this.pictureBoxUploadedImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxUploadedImg.Location = new System.Drawing.Point(121, 45);
            this.pictureBoxUploadedImg.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxUploadedImg.MaximumSize = new System.Drawing.Size(360, 290);
            this.pictureBoxUploadedImg.MinimumSize = new System.Drawing.Size(360, 290);
            this.pictureBoxUploadedImg.Name = "pictureBoxUploadedImg";
            this.pictureBoxUploadedImg.Size = new System.Drawing.Size(360, 290);
            this.pictureBoxUploadedImg.TabIndex = 1;
            this.pictureBoxUploadedImg.TabStop = false;
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Location = new System.Drawing.Point(441, 15);
            this.btnApply.Margin = new System.Windows.Forms.Padding(40, 15, 40, 15);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(122, 51);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "??";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // PhotoUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 544);
            this.Controls.Add(this.layoutOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(625, 600);
            this.MinimumSize = new System.Drawing.Size(625, 600);
            this.Name = "PhotoUploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.layoutOuter.ResumeLayout(false);
            this.layoutOuter.PerformLayout();
            this.layoutMiddle.ResumeLayout(false);
            this.layoutBottom.ResumeLayout(false);
            this.layoutBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadedImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel layoutOuter;
        private TableLayoutPanel layoutMiddle;
        private TableLayoutPanel layoutBottom;
        private PictureBox pictureBoxUploadedImg;
        private Label labelFormatOption;
        private Label labelPlayerName;
        private Button btnUpload;
        private Button btnApply;
    }
}