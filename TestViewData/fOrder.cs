using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TestViewData
{
    public partial class fOrder : Form
    {
        public string IDDoc { get { return textBox1.Text; } }
        public string Sum { get { return textBox2.Text; } }

        public fOrder()
        {
            InitializeComponent();
        }


        private void bSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
