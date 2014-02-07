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

namespace BoardMultiplier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public DataView dsData;
        private CSVLoader csvload = new CSVLoader();


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    dsData = csvload.LoadCSV(file);
                    textBoxInfo.Text = "Loaded " + dsData.Count.ToString() + " components.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, textBoxOut.Text);
            MessageBox.Show("New PCB file saved.");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            float boardsX = float.Parse(textBoxPCBX.Text.ToString());
            float boardsY = float.Parse(textBoxPCBY.Text.ToString());
            float offsetX = float.Parse(textBoxBoardOffsetX.Text.ToString());
            float offsetY = float.Parse(textBoxBoardOffsetY.Text.ToString());

            StringBuilder sb = new StringBuilder();
            sb.Append("RefDes,Type,X (mm),Y (mm),Side,Rotate,Value,Feeder,Code" + Environment.NewLine);
            // loop across Y axis
            for (float y = 0; y < boardsY; y++)
            {

                for (float x = 0; x < boardsX; x++)
                {
                    foreach (DataRowView drv in dsData)
                    {
                        float oldx = float.Parse(drv["PosX"].ToString());
                        float oldy = float.Parse(drv["PosY"].ToString());
                       // float newx = CalcNewLocationValue(, x, oldx);
                        float newx = ((x * offsetX) + oldx);
                        //float newy = CalcNewLocationValue(offsetY, y, oldy);
                        float newy = ((y * offsetY) + oldy);
                        sb.Append(drv["RefDes"].ToString() + "," + drv["Type"].ToString() + "," + newx.ToString() + "," + newy.ToString() + "," + drv["Side"].ToString() + "," + drv["Rotate"].ToString() + "," + drv["Value"].ToString() + "," + drv["Feeder"].ToString() + "," + drv["Code"].ToString() + Environment.NewLine);
                    }
                }
            }

            textBoxOut.Text = sb.ToString();
            saveFileDialog1.Filter = "CSV files|*.csv";
            saveFileDialog1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public float CalcNewLocationValue(float BoardOffset, float currentrow, float currentval)
        {
            return ((BoardOffset * currentrow) + currentval);
        }
    }
}
