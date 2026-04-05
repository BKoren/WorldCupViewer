using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Exceptions;
using WorldCup.DataLayer.Settings;

namespace WorldCup.DataLayer
{
    public class LanguageManager : Base
    {
        internal static void InitializeLanguageKeys()
        {
            InitializeCompilerCode(new Dictionary<string, string>
            {
                { "English", "en" },
                { "Engleski", "en" },
                { "Croatian", "hr" },
                { "Hrvatski", "hr" }
            });
        }
        public static void ApplyLanguage()
        {
            if (!string.IsNullOrEmpty(SettingsManager.Language))
            {
                var culture = new CultureInfo(SettingsManager.Language);

                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
            }
        }
    }
}
