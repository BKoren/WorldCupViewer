using System.Windows.Forms;

namespace WorldCup.WinForms.Controls
{
    partial class PlayerControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            pictureBoxPlayer.Image?.Dispose();
            pictureBoxPlayer.Image = null;

            ClickHandler = null;
            moveHandler = null;
            leaveHandler = null;

            if (disposing && (components != null))
            {
                pictureBoxPlayer.MouseLeave -= leaveHandler;
                pictureBoxPlayer.MouseMove -= moveHandler;
                pictureBoxPlayer.MouseDown -= PlayerControl_MouseDown;
                pictureBoxPlayer.MouseUp -= PlayerControl_MouseUp;
                pictureBoxPlayer.Click -= PlayerControl_Click;

                star.MouseLeave -= leaveHandler;
                star.MouseMove -= moveHandler;
                star.MouseDown -= PlayerControl_MouseDown;
                star.MouseUp -= PlayerControl_MouseUp;
                star.Click -= PlayerControl_Click;

                star?.Dispose();
                star = null;

                components?.Dispose();

                base.Dispose(disposing);
            }
        }

        #region Component Designer generated code        
        private void InitializeComponent()
        {
            this.layoutPlayerControl = new System.Windows.Forms.TableLayoutPanel();
            this.labelContent1 = new System.Windows.Forms.Label();
            this.labelContent2 = new System.Windows.Forms.Label();
            this.labelContent3 = new System.Windows.Forms.Label();
            this.labelContent4 = new System.Windows.Forms.Label();
            this.panelImgHolder = new System.Windows.Forms.Panel();
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            this.layoutPlayerControl.SuspendLayout();
            this.panelImgHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutPlayerControl
            // 
            this.layoutPlayerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutPlayerControl.BackColor = System.Drawing.Color.SeaShell;
            this.layoutPlayerControl.ColumnCount = 6;
            this.layoutPlayerControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.22595F));
            this.layoutPlayerControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.24832F));
            this.layoutPlayerControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.08054F));
            this.layoutPlayerControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.59508F));
            this.layoutPlayerControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.85011F));
            this.layoutPlayerControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPlayerControl.Controls.Add(this.labelContent1, 1, 0);
            this.layoutPlayerControl.Controls.Add(this.labelContent2, 2, 0);
            this.layoutPlayerControl.Controls.Add(this.labelContent3, 3, 0);
            this.layoutPlayerControl.Controls.Add(this.labelContent4, 4, 0);
            this.layoutPlayerControl.Controls.Add(this.panelImgHolder, 0, 0);
            this.layoutPlayerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutPlayerControl.Location = new System.Drawing.Point(0, 0);
            this.layoutPlayerControl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.layoutPlayerControl.Name = "layoutPlayerControl";
            this.layoutPlayerControl.RowCount = 1;
            this.layoutPlayerControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPlayerControl.Size = new System.Drawing.Size(896, 93);
            this.layoutPlayerControl.TabIndex = 3;
            // 
            // labelContent1
            // 
            this.labelContent1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent1.AutoSize = true;
            this.labelContent1.Location = new System.Drawing.Point(307, 36);
            this.labelContent1.Name = "labelContent1";
            this.labelContent1.Size = new System.Drawing.Size(27, 20);
            this.labelContent1.TabIndex = 1;
            this.labelContent1.Text = "??";
            // 
            // labelContent2
            // 
            this.labelContent2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent2.AutoSize = true;
            this.labelContent2.Location = new System.Drawing.Point(527, 36);
            this.labelContent2.Name = "labelContent2";
            this.labelContent2.Size = new System.Drawing.Size(27, 20);
            this.labelContent2.TabIndex = 2;
            this.labelContent2.Text = "??";
            // 
            // labelContent3
            // 
            this.labelContent3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent3.AutoSize = true;
            this.labelContent3.Location = new System.Drawing.Point(682, 36);
            this.labelContent3.Name = "labelContent3";
            this.labelContent3.Size = new System.Drawing.Size(27, 20);
            this.labelContent3.TabIndex = 3;
            this.labelContent3.Text = "??";
            // 
            // labelContent4
            // 
            this.labelContent4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent4.AutoSize = true;
            this.labelContent4.Location = new System.Drawing.Point(832, 36);
            this.labelContent4.Margin = new System.Windows.Forms.Padding(0);
            this.labelContent4.Name = "labelContent4";
            this.labelContent4.Size = new System.Drawing.Size(27, 20);
            this.labelContent4.TabIndex = 5;
            this.labelContent4.Text = "??";
            // 
            // panelImgHolder
            // 
            this.panelImgHolder.BackColor = System.Drawing.SystemColors.Control;
            this.panelImgHolder.Controls.Add(this.pictureBoxPlayer);
            this.panelImgHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImgHolder.Location = new System.Drawing.Point(0, 0);
            this.panelImgHolder.Margin = new System.Windows.Forms.Padding(0);
            this.panelImgHolder.Name = "panelImgHolder";
            this.panelImgHolder.Padding = new System.Windows.Forms.Padding(4);
            this.panelImgHolder.Size = new System.Drawing.Size(154, 93);
            this.panelImgHolder.TabIndex = 6;
            // 
            // pictureBoxPlayer
            // 
            this.pictureBoxPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPlayer.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.Size = new System.Drawing.Size(146, 85);
            this.pictureBoxPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayer.TabIndex = 1;
            this.pictureBoxPlayer.TabStop = false;
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.layoutPlayerControl);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(896, 93);
            this.layoutPlayerControl.ResumeLayout(false);
            this.layoutPlayerControl.PerformLayout();
            this.panelImgHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutPlayerControl;
        private System.Windows.Forms.PictureBox pictureBoxPlayer;
        private System.Windows.Forms.Label labelContent1;
        private System.Windows.Forms.Label labelContent2;
        private System.Windows.Forms.Label labelContent3;
        private System.Windows.Forms.Label labelContent4;
        private System.Windows.Forms.Panel panelImgHolder;
    }
}
