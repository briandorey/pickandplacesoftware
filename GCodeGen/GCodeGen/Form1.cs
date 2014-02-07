using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;     // DLL support
using System.IO;
using System.Text.RegularExpressions;




namespace PNPController
{
    public partial class Form1 : Form
    {
        
        public DataSet dsFeeders;
        // vision 
      

        private delegate void SetTextCallback(System.Windows.Forms.Control control, string text);
       

        private ComponentFeeders cf = new ComponentFeeders();
        private CSVLoader csvload = new CSVLoader();
        private DataToMach3 dtom3 = new DataToMach3();
        public Form1()
        {
            InitializeComponent();
           
            this.FormClosing += new FormClosingEventHandler(Form_FormClosing);

            dsFeeders = cf.POPFeedersTable();

            dataGridViewFeeders.DataSource = dsFeeders.Tables[0];

            dataGridViewFeeders.AllowUserToAddRows = true;
            dataGridViewFeeders.AllowUserToDeleteRows = true;
            dataGridViewFeeders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            dataGridViewFeeders.AutoResizeColumns();
            dataGridViewFeeders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewFeeders.AutoGenerateColumns = true;
            csvload.SetupGridView(dataGridView1);
            
        }

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            Application.DoEvents();
        }

     

        // Delegates to enable async calls for setting controls properties



     
       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

      

        private void Form1_Load(object sender, EventArgs e)
        {
          //  usbCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);

          //  foreach (FilterInfo camera in usbCams)
          //  {
          //      comboBox1.Items.Add(camera.Name);

           // }


        }

        

       

        private void openBoardFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    csvload.LoadCSV(file, dataGridView1);
                }
                catch
                {

                }
            }
        }

        private void feedersToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            FileStream findata = new FileStream(Path.Combine(Application.StartupPath, "feeders.xml"), FileMode.Open,
                                 FileAccess.ReadWrite, FileShare.ReadWrite);
            dsFeeders.WriteXml(findata);
        }

        

        private void buttonSaveGCode_Click(object sender, EventArgs e)
        {
            // save gcode to file
            saveFileDialog1.Filter = "NC files|*.nc";
            saveFileDialog1.ShowDialog();
        }

        private void buttonStartGode_Click(object sender, EventArgs e)
        {
            DataToMach3 dt = new DataToMach3();
            textBoxGCode.Text = dt.ConvertToGCode(dataGridView1, Double.Parse(textBoxBoardOffsetX.Text), Double.Parse(textBoxBoardOffsetY.Text), textBoxRunSpeed.Text); 
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, textBoxGCode.Text);
        }

       
    }
}
