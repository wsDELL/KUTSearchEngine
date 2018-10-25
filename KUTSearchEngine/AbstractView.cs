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
    public partial class AbstractView : Form
    {
        public AbstractView()
        {
            InitializeComponent();
            textBox1.Text = GlobalData.abstractContent;
        }

    }
}
