using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNPControllerKFlop
{
    public partial class ManualPicker : Form
    {
        public ManualPicker()
        {
            InitializeComponent();
        }

        private void ManualPicker_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 16; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.SelectedIndex = 0;

        }

        private void buttonActiveandPick_Click(object sender, EventArgs e)
        {

        }

        private void buttonPickerUP_Click(object sender, EventArgs e)
        {

        }

        private void buttonPickerDown_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {

        }
    }
}
