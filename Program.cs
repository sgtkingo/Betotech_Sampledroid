using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Velopack;

namespace ConcreteSampleTransformers
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Must be first: handles Velopack install/update/uninstall hooks (process may exit inside Run)
            VelopackApp.Build().Run();

            UpgradeSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm());
        }

        //Every version has its own user.config, take user settings from previous version once
        private static void UpgradeSettings()
        {
            if (!Properties.Settings.Default.upgradeRequired) return;

            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.upgradeRequired = false;
            Properties.Settings.Default.Save();
        }
    }
}
