using System;
using System.Windows.Forms;

namespace WorldCup.WinForms
{
    partial class Base
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            this.Icon?.Dispose();
            this.BackgroundImage?.Dispose();

            if (disposing && (components != null))
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "BaseForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base";
            this.Load += new System.EventHandler(this.FormBase_FormLoad);
            this.ResumeLayout(false);

        }
        #endregion
    }
}