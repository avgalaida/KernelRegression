using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KernelRegression
{

    public partial class Form2 : Form
    {
        public double x;
        public double y;

        public Form2()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            x = (double) xNumericUpDown.Value;
            y = (double) yNumericUpDown.Value;
            this.DialogResult = DialogResult.OK;   
            this.Close();
        }
    }
}
