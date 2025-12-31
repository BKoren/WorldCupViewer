namespace WorldCup.WinForms.Dialogs
{
    partial class Loading
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
            this.layoutOuter = new System.Windows.Forms.TableLayoutPanel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.layoutOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutOuter
            // 
            this.layoutOuter.ColumnCount = 1;
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutOuter.Controls.Add(this.labelLoading, 0, 0);
            this.layoutOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOuter.Location = new System.Drawing.Point(0, 0);
            this.layoutOuter.Name = "layoutOuter";
            this.layoutOuter.RowCount = 1;
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutOuter.Size = new System.Drawing.Size(800, 450);
            this.layoutOuter.TabIndex = 0;
            // 
            // labelLoading
            // 
            this.labelLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLoading.Location = new System.Drawing.Point(363, 190);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(74, 69);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "\"\"";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutOuter);
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.layoutOuter.ResumeLayout(false);
            this.layoutOuter.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutOuter;
        private System.Windows.Forms.Label labelLoading;
    }
}