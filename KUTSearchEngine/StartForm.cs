using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KUTSearchEngine
{
    public partial class StartForm : Form
    {

        
        public StartForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalData.createIndexPath==null || GlobalData.soureCollectionPath==null)
            {
                MessageBox.Show("Invalid input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
         
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openSourceCollectionFileDialog.ShowDialog();
            browswShow.Text = openSourceCollectionFileDialog.SelectedPath;
            GlobalData.soureCollectionPath = openSourceCollectionFileDialog.SelectedPath;
        }
              
        

        private void createIndexButton_Click(object sender, EventArgs e)
        {
            openIndexFileDialog.ShowDialog();
            indexPathShow.Text = openIndexFileDialog.SelectedPath;
            GlobalData.createIndexPath = openIndexFileDialog.SelectedPath;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
