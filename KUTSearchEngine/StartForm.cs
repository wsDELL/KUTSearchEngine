using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUTSearchEngine
{
    public partial class StartForm : Form
    {
        Form startForm;
        Form1 form1 = new Form1();
        public StartForm(Form form)
        {
            InitializeComponent();
            this.startForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Form2_FormClosing(object sender, EventArgs e)
        {
            
            
            //Lucene.Net.Documents.Document doc = form1.myLuceneApp.GetSearcher.Doc(scoreDoc.Doc);
            this.Hide();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string displayResult=form1.fileContent[form1.selectedItemIndex][5];
            listBox1.Items.Add(displayResult);
        }
    }
}
