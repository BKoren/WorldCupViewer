using System.Windows.Forms;

namespace WorldCup.WinForms.Controls
{
    partial class MatchControl
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.layoutMatchControl = new System.Windows.Forms.TableLayoutPanel();
            this.labelContent1 = new System.Windows.Forms.Label();
            this.labelContent2 = new System.Windows.Forms.Label();
            this.labelContent3 = new System.Windows.Forms.Label();
            this.labelContent4 = new System.Windows.Forms.Label();
            this.labelContent5 = new System.Windows.Forms.Label();
            this.layoutMatchControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutMatchControl
            // 
            this.layoutMatchControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutMatchControl.BackColor = System.Drawing.Color.SeaShell;
            this.layoutMatchControl.ColumnCount = 5;
            this.layoutMatchControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.layoutMatchControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.layoutMatchControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.layoutMatchControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.2F));
            this.layoutMatchControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.8F));
            this.layoutMatchControl.Controls.Add(this.labelContent1, 0, 0);
            this.layoutMatchControl.Controls.Add(this.labelContent2, 1, 0);
            this.layoutMatchControl.Controls.Add(this.labelContent3, 2, 0);
            this.layoutMatchControl.Controls.Add(this.labelContent4, 3, 0);
            this.layoutMatchControl.Controls.Add(this.labelContent5, 4, 0);
            this.layoutMatchControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutMatchControl.Location = new System.Drawing.Point(0, 0);
            this.layoutMatchControl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.layoutMatchControl.Name = "layoutMatchControl";
            this.layoutMatchControl.RowCount = 1;
            this.layoutMatchControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMatchControl.Size = new System.Drawing.Size(894, 93);
            this.layoutMatchControl.TabIndex = 0;
            // 
            // labelContent1
            // 
            this.labelContent1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent1.AutoSize = true;
            this.labelContent1.Location = new System.Drawing.Point(84, 36);
            this.labelContent1.Name = "labelContent1";
            this.labelContent1.Size = new System.Drawing.Size(27, 20);
            this.labelContent1.TabIndex = 0;
            this.labelContent1.Text = "??";
            // 
            // labelContent2
            // 
            this.labelContent2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent2.AutoSize = true;
            this.labelContent2.Location = new System.Drawing.Point(280, 36);
            this.labelContent2.Name = "labelContent2";
            this.labelContent2.Size = new System.Drawing.Size(27, 20);
            this.labelContent2.TabIndex = 1;
            this.labelContent2.Text = "??";
            // 
            // labelContent3
            // 
            this.labelContent3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent3.AutoSize = true;
            this.labelContent3.Location = new System.Drawing.Point(476, 36);
            this.labelContent3.Name = "labelContent3";
            this.labelContent3.Size = new System.Drawing.Size(27, 20);
            this.labelContent3.TabIndex = 2;
            this.labelContent3.Text = "??";
            // 
            // labelContent4
            // 
            this.labelContent4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent4.AutoSize = true;
            this.labelContent4.Location = new System.Drawing.Point(646, 36);
            this.labelContent4.Name = "labelContent4";
            this.labelContent4.Size = new System.Drawing.Size(27, 20);
            this.labelContent4.TabIndex = 3;
            this.labelContent4.Text = "??";
            // 
            // labelContent5
            // 
            this.labelContent5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelContent5.AutoSize = true;
            this.labelContent5.Location = new System.Drawing.Point(797, 36);
            this.labelContent5.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labelContent5.Name = "labelContent5";
            this.labelContent5.Size = new System.Drawing.Size(27, 20);
            this.labelContent5.TabIndex = 4;
            this.labelContent5.Text = "??";
            this.labelContent5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.layoutMatchControl);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MatchControl";
            this.Size = new System.Drawing.Size(894, 93);
            this.layoutMatchControl.ResumeLayout(false);
            this.layoutMatchControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel layoutMatchControl;
        private Label labelContent1;
        private Label labelContent2;
        private Label labelContent3;
        private Label labelContent4;
        private Label labelContent5;
    }
}
