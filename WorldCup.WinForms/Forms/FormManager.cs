using System.Windows.Forms;
using WorldCup.DataLayer;

namespace WorldCup.WinForms
{
    public class FormManager : ApplicationContext
    {
        internal bool Loading = true;
        internal bool LoadingNessecary = false;

        internal bool AbortForm = false;
        public FormManager()
        {
            SettingsManager.WPF = false;

            Base start;            

            if (!SettingsManager.CheckForSettings())
                start = new Settings.StartUp(this);
                
            else
                start = new TeamSelection(this);

            TransitionNext(start);
        }
        public void TransitionNext(Base next)
        {
            Form current = this.MainForm;
            current?.Hide();

            next.ShowAsync();
                          
            if(!AbortForm)
            {
                this.MainForm = next as Form;
    
                current?.Dispose();
            }
        }
    }
}

