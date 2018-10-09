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
    public partial class Form2 : Form
    {
        private Form1 anotherForm;
        public Form2()
        {
            InitializeComponent();
            anotherForm = new Form1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anotherForm = new Form1();
            this.Hide();
            anotherForm.ShowDialog();
            Application.ExitThread();
        }
    }
}
