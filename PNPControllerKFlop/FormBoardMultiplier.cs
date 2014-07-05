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
using System.Text.RegularExpressions;


namespace PNPControllerKFlop
{
    public partial class FormBoardMultiplier : Form
    {
        public FormBoardMultiplier()
        {
            InitializeComponent();
        }
        public DataView dsData;
        private CSVLoader csvload = new CSVLoader();
        public StringBuilder sbData = new StringBuilder();
        DataTable dt = new DataTable();
        private DataSet dscomponents = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            sbData.Clear();
            openFileDialog1.Filter = "XML files|*.xml";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;

                dt.Clear();
                try
                {
                    dscomponents.Tables.RemoveAt(0);
                }
                catch { }
                try
                {
                    dscomponents.Tables.RemoveAt(1);
                }
                catch { }
                FileStream finschema = new FileStream(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\board.xsd", FileMode.Open, FileAccess.Read, FileShare.Read);
                dscomponents.ReadXmlSchema(finschema);
                finschema.Close();
                FileStream findata = new FileStream(file, FileMode.Open,
                                     FileAccess.Read, FileShare.ReadWrite);
                dscomponents.ReadXml(findata);
                findata.Close();
                dsData = new DataView(dscomponents.Tables["Component"]);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, sbData.ToString());
            MessageBox.Show("New PCB file saved.");
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            float boardsX = float.Parse(textBoxPCBX.Text.ToString());
            float boardsY = float.Parse(textBoxPCBY.Text.ToString());
            float offsetX = float.Parse(textBoxBoardOffsetX.Text.ToString());
            float offsetY = float.Parse(textBoxBoardOffsetY.Text.ToString());

            sbData.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + Environment.NewLine);
            sbData.Append("<pcbboard>" + Environment.NewLine);
            sbData.Append("<ComponentList>" + Environment.NewLine);


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
                        // sbData.Append(drv["RefDes"].ToString() + "," + drv["Type"].ToString() + "," + newx.ToString() + "," + newy.ToString() + "," + drv["Side"].ToString() + "," + drv["Rotate"].ToString() + "," + drv["Value"].ToString() + "," + drv["Feeder"].ToString() + "," + drv["Code"].ToString() + Environment.NewLine);
                        sbData.Append(" <Component>" + Environment.NewLine);
                        sbData.Append("     <RefDes>" + drv["RefDes"].ToString() + " y" + y.ToString() + "  x" + x.ToString() + "</RefDes>" + Environment.NewLine);
                        sbData.Append("     <Type>" + drv["Type"].ToString() + "</Type>" + Environment.NewLine);
                        sbData.Append("     <Value>" + drv["Value"].ToString() + "</Value>" + Environment.NewLine);
                        sbData.Append("     <PosX>" + newx.ToString() + "</PosX>" + Environment.NewLine);
                        sbData.Append("     <PosY>" + newy.ToString() + "</PosY>" + Environment.NewLine);
                        sbData.Append("     <Rotate>" + drv["Rotate"].ToString() + "</Rotate>" + Environment.NewLine);
                        sbData.Append("     <feederNumber>" + drv["feederNumber"].ToString() + "</feederNumber>" + Environment.NewLine);
                        sbData.Append("     <ComponentCode>" + drv["ComponentCode"].ToString() + "</ComponentCode>" + Environment.NewLine);
                        sbData.Append("   </Component>" + Environment.NewLine);

                    }
                }
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
    }


}
