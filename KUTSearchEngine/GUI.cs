using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUTSearchEngine
{
    static class GUI
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartForm startForm = new StartForm();
            startForm.ShowDialog();
            if (startForm.DialogResult == DialogResult.OK)
            {
                Form1 form1 = new Form1();
                form1.SourceCollectionPath(GlobalData.soureCollectionPath);
                form1.IndexBrowse(GlobalData.createIndexPath);
                Application.Run(form1);
               
                
            }


        }
    }
}
