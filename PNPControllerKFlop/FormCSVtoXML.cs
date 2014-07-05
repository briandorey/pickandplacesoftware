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

namespace PNPControllerKFlop
{
    public partial class FormCSVtoXML : Form
    {
        public FormCSVtoXML()
        {
            InitializeComponent();
        }

        public DataView dsData;
        private CSVLoader csvload = new CSVLoader();

        public StringBuilder sbData = new StringBuilder();

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, sbData.ToString());
            MessageBox.Show("New file saved.");
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            sbData.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine);
            sbData.Append("<pcbboard>" + Environment.NewLine);
            sbData.Append("<ComponentList>" + Environment.NewLine);
                    foreach (DataRowView drv in dsData)
                    {
                        sbData.Append(" <Component>" + Environment.NewLine);
                        sbData.Append("     <RefDes>" + drv["RefDes"].ToString() + "</RefDes>" + Environment.NewLine);
                        sbData.Append("     <Type>" + drv["Type"].ToString() + "</Type>" + Environment.NewLine);
                        sbData.Append("     <Value>" + drv["Value"].ToString() + "</Value>" + Environment.NewLine);
                        sbData.Append("     <PosX>" + drv["PosX"].ToString() + "</PosX>" + Environment.NewLine);
                        sbData.Append("     <PosY>" + drv["PosY"].ToString() + "</PosY>" + Environment.NewLine);
                        sbData.Append("     <Rotate>" + drv["Rotate"].ToString() + "</Rotate>" + Environment.NewLine);
                        sbData.Append("     <feederNumber>" + drv["Feeder"].ToString() + "</feederNumber>" + Environment.NewLine);
                        sbData.Append("     <ComponentCode>" + drv["Code"].ToString() + "</ComponentCode>" + Environment.NewLine);
                        sbData.Append("   </Component>" + Environment.NewLine);                       
                    }
            
            sbData.Append("</ComponentList>" + Environment.NewLine);
            sbData.Append("<BoardDefaults>" + Environment.NewLine);
            sbData.Append("  <Settings>" + Environment.NewLine);
            sbData.Append("    <BoardOffsetX>" + Properties.Settings.Default.Properties["SettingBoardOffsetX"].DefaultValue.ToString() + "</BoardOffsetX>" + Environment.NewLine);
            sbData.Append("    <BoardOffsetY>" + Properties.Settings.Default.Properties["SettingBoardOffsetY"].DefaultValue.ToString() + "</BoardOffsetY>" + Environment.NewLine);
            sbData.Append("    <FeedRate>" + Properties.Settings.Default.Properties["SettingFeedRate"].DefaultValue.ToString() + "</FeedRate>" + Environment.NewLine);
            sbData.Append("    <PCBThickness>" + Properties.Settings.Default.Properties["SettingPCBThickness"].DefaultValue.ToString() + "</PCBThickness>" + Environment.NewLine);
            sbData.Append("    <chipfeederms>" + Properties.Settings.Default.Properties["SettingTimeMS"].DefaultValue.ToString() + "</chipfeederms>" + Environment.NewLine);
            sbData.Append("  </Settings>" + Environment.NewLine);
            sbData.Append("</BoardDefaults>" + Environment.NewLine);
            sbData.Append("</pcbboard>" + Environment.NewLine);
          
            saveFileDialog1.Filter = "XML files|*.xml";
            saveFileDialog1.ShowDialog();
        }

      

        public float CalcNewLocationValue(float BoardOffset, float currentrow, float currentval)
        {
            return ((BoardOffset * currentrow) + currentval);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            sbData.Clear();
            openFileDialog1.Filter = "CSV files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    dsData = csvload.LoadCSV(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }

   
}
