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

namespace csvboardtoxml
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
            MessageBox.Show("New file saved.");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine);
            sb.Append("<pcbboard>" + Environment.NewLine);
            sb.Append("<ComponentList>" + Environment.NewLine);

            sb.Append("RefDes,Type,X (mm),Y (mm),Side,Rotate,Value,Feeder,Code" + Environment.NewLine);
            // loop across Y axis
     
                    foreach (DataRowView drv in dsData)
                    {
                        sb.Append(" <Component>" + Environment.NewLine);
                        sb.Append("     <RefDes>" + drv["RefDes"].ToString() + "</RefDes>" + Environment.NewLine);
                        sb.Append("     <Type>" + drv["Type"].ToString() + "</Type>" + Environment.NewLine);
                        sb.Append("     <Value>" + drv["Value"].ToString() + "</Value>" + Environment.NewLine);
                        sb.Append("     <PosX>" + drv["PosX"].ToString() + "</PosX>" + Environment.NewLine);
                        sb.Append("     <PosY>" + drv["PosY"].ToString() + "</PosY>" + Environment.NewLine);
                        sb.Append("     <Rotate>" + drv["Rotate"].ToString() + "</Rotate>" + Environment.NewLine);
                        sb.Append("     <feederNumber>" + drv["Feeder"].ToString() + "</feederNumber>" + Environment.NewLine);
                        sb.Append("     <ComponentCode>" + drv["Code"].ToString() + "</ComponentCode>" + Environment.NewLine);
                        sb.Append("   </Component>" + Environment.NewLine);                       
                    }
            
            sb.Append("</ComponentList>" + Environment.NewLine);
            sb.Append("<BoardDefaults>" + Environment.NewLine);
            sb.Append("  <Settings>" + Environment.NewLine);
            sb.Append("    <BoardOffsetX>123</BoardOffsetX>" + Environment.NewLine);
            sb.Append("    <BoardOffsetY>456</BoardOffsetY>" + Environment.NewLine);
            sb.Append("    <FeedRate>789</FeedRate>" + Environment.NewLine);
            sb.Append("    <PCBThickness>1.0</PCBThickness>" + Environment.NewLine);
            sb.Append("    <chipfeederms>800</chipfeederms>" + Environment.NewLine);
            sb.Append("  </Settings>" + Environment.NewLine);
            sb.Append("</BoardDefaults>" + Environment.NewLine);
            sb.Append("</pcbboard>" + Environment.NewLine);
            textBoxOut.Text = sb.ToString();
            saveFileDialog1.Filter = "XML files|*.xml";
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
