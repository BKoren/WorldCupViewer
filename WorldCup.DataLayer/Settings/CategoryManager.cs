using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer.Settings;

namespace WorldCup.DataLayer
{
    public class CategoryManager : Base
    {
        public static void InitializeCategory()
        {
            InitializeCompilerCode(new Dictionary<string, string>
            {
                { "Man", "M" },
                { "Muškarci", "M" },
                { "Woman", "F" },
                { "Žene", "F" }
            });
        }
    }
}
