using System.Windows.Forms;

namespace WorldCup.WinForms.Dialogs
{
    partial class ExitConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitConfirmation));
            this.layoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.layoutUpper = new System.Windows.Forms.TableLayoutPanel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.layoutBottom.SuspendLayout();
            this.layoutUpper.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutBottom
            // 
            this.layoutBottom.ColumnCount = 3;
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutBottom.Controls.Add(this.btnNo, 2, 0);
            this.layoutBottom.Controls.Add(this.btnYes, 0, 0);
            this.layoutBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutBottom.Location = new System.Drawing.Point(0, 350);
            this.layoutBottom.Margin = new System.Windows.Forms.Padding(0);
            this.layoutBottom.Name = "layoutBottom";
            this.layoutBottom.RowCount = 1;
            this.layoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottom.Size = new System.Drawing.Size(800, 100);
            this.layoutBottom.TabIndex = 0;
            // 
            // BtnYes
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNo.AutoSize = true;
            this.btnNo.Location = new System.Drawing.Point(665, 30);
            this.btnNo.Margin = new System.Windows.Forms.Padding(0, 0, 15, 25);
            this.btnNo.Name = "BtnYes";
            this.btnNo.Size = new System.Drawing.Size(120, 45);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "?";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // BtnNo
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.AutoSize = true;
            this.btnYes.Location = new System.Drawing.Point(15, 30);
            this.btnYes.Margin = new System.Windows.Forms.Padding(15, 0, 0, 25);
            this.btnYes.Name = "BtnNo";
            this.btnYes.Size = new System.Drawing.Size(120, 45);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "?";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // layoutUpper
            // 
            this.layoutUpper.ColumnCount = 1;
            this.layoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutUpper.Controls.Add(this.labelMessage, 0, 0);
            this.layoutUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutUpper.Location = new System.Drawing.Point(0, 0);
            this.layoutUpper.Name = "layoutUpper";
            this.layoutUpper.RowCount = 1;
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.layoutUpper.Size = new System.Drawing.Size(800, 350);
            this.layoutUpper.TabIndex = 1;
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMessage.Location = new System.Drawing.Point(387, 160);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(25, 29);
            this.labelMessage.TabIndex = 5;
            this.labelMessage.Text = "?";
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutUpper);
            this.Controls.Add(this.layoutBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfirmationForm";
            this.layoutBottom.ResumeLayout(false);
            this.layoutBottom.PerformLayout();
            this.layoutUpper.ResumeLayout(false);
            this.layoutUpper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutBottom;
        private System.Windows.Forms.TableLayoutPanel layoutUpper;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label labelMessage;
    }
}