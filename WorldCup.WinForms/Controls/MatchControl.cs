using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldCup.WinForms.Controls
{
    public partial class MatchControl : UserControl
    {
        public MatchControl()
        {
            InitializeComponent();

            ModifyControls(this, Color.White);
        }
        
        internal string ColumnContent1 
        {
            get => labelContent1.Text;
            set => labelContent1.Text = value;
        }
        internal string ColumnContent2 
        {
            get => labelContent2.Text;
            set => labelContent2.Text = value;
        }
        internal string ColumnContent3 
        {
            get => labelContent3.Text; 
            set => labelContent3.Text = value; 
        }
        internal string ColumnContent4 
        {
            get => labelContent4.Text; 
            set => labelContent4.Text = value; 
        } 
        internal string ColumnContent5 
        {
            get => labelContent5.Text; 
            set => labelContent5.Text = value; 
        }

        private void ModifyControls(Control playerControl, Color color)
        {
            foreach (Control control in playerControl.Controls)
            {
                control.BackColor = color;

                if (control.HasChildren)
                    ModifyControls(control, color);
            }
        }
    }
}
