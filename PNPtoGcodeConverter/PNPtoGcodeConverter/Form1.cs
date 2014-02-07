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

namespace PNPtoGcodeConverter
{
    public partial class Form1 : Form
    {

        DataSet ds = new DataSet();
        
        DataTable dt = new DataTable();
       
        DataTable dtFeeders = new DataTable();
        DataTable dtCode = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            openFileDialog1.Filter = "CSV files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {

                    POPDataTable();
                    POPFeedersTable();
                    string text = File.ReadAllText(file);
                   // size = text.Length;
                   // textBox1.Text = text;

                    int counter = 1;
                    string[] sites = text.Split('\n');
                    if (sites.Length <= 1)
                    {
                        //Loader.Append(DateTime.Now.ToString() + " Empty Data File<br>");

                    }
                    else
                    {
                      //  Loader.Append(DateTime.Now.ToString() + " Load Completed<br>");
                        foreach (string s in sites)
                        {
                            string tmprow = s;
                            MatchCollection matches2 = Regex.Matches(tmprow, @"""(.*?)""");
                            foreach (Match match in matches2)
                            {
                                foreach (Capture capture in match.Captures)
                                {
                                    string tmpitem = capture.Value.Replace(",", "");
                                    tmprow = tmprow.Replace(capture.Value, tmpitem);
                                }
                            }

                            string[] names = tmprow.Split(',');
                            if (names.Length <= 1)
                            {
                               // Loader.Append("CSV stock data has missing rows or data: " + names.Length + "<br>");
                            }
                            else
                            {
                                if (!names[0].ToString().Equals("RefDes"))
                                {
                                    dt.Rows.Add(names[0].ToString(),
                                        names[1].ToString(),
                                        Double.Parse(names[2].ToString()),
                                        Double.Parse(names[3].ToString()),
                                        Int32.Parse(names[5].ToString()),
                                        names[6].ToString(),
                                        "0");
                                }
                                counter++;
                            }

                        }
                    }


                }
                catch (IOException)
                {
                }

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
             

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;


                DataGridViewTextBoxColumn dgvc1 = new DataGridViewTextBoxColumn();
                dgvc1.DataPropertyName = "RefDes";
                dgvc1.HeaderText = "RefDes";
                dataGridView1.Columns.Add(dgvc1);

                DataGridViewTextBoxColumn dgvc2 = new DataGridViewTextBoxColumn();
                dgvc2.DataPropertyName = "Type";
                dgvc2.HeaderText = "Type";
                dataGridView1.Columns.Add(dgvc2);

                DataGridViewTextBoxColumn dgvc3 = new DataGridViewTextBoxColumn();
                dgvc3.DataPropertyName = "PosX";
                dgvc3.HeaderText = "PosX";
                dataGridView1.Columns.Add(dgvc3);

                DataGridViewTextBoxColumn dgvc4 = new DataGridViewTextBoxColumn();
                dgvc4.DataPropertyName = "PosY";
                dgvc4.HeaderText = "PosY";
                dataGridView1.Columns.Add(dgvc4);

                DataGridViewTextBoxColumn dgvc5 = new DataGridViewTextBoxColumn();
                dgvc5.DataPropertyName = "Rotate";
                dgvc5.HeaderText = "Rotate";
                dataGridView1.Columns.Add(dgvc5);

                DataGridViewTextBoxColumn dgvc6 = new DataGridViewTextBoxColumn();
                dgvc6.DataPropertyName = "Value";
                dgvc6.HeaderText = "Value";
                dataGridView1.Columns.Add(dgvc6);

                DataGridViewComboBoxColumn ColumnItem = new DataGridViewComboBoxColumn();
                ColumnItem.DataPropertyName = "feederNumber";
                ColumnItem.HeaderText = "Feeder Number";
                ColumnItem.Width = 120;

                ColumnItem.DataSource = ds.Tables[0];
                ColumnItem.ValueMember = "feederNumber";
                ColumnItem.DisplayMember = "feederValue";

                dataGridView1.Columns.Add(ColumnItem);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;
            }
            
            
        }

       
        private void POPDataTable()
        {
            dt.Columns.Add("RefDes", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("PosX", typeof(double));
            dt.Columns.Add("PosY", typeof(double));
            dt.Columns.Add("Rotate", typeof(int));
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("feederNumber", typeof(string));

            dtCode.Columns.Add("RefDes", typeof(string));
            dtCode.Columns.Add("ComponentType", typeof(string));
            dtCode.Columns.Add("PosX", typeof(double));
            dtCode.Columns.Add("PosY", typeof(double));
            dt.Columns.Add("FeederRotate", typeof(int));
            dtCode.Columns.Add("Value", typeof(string));
            dtCode.Columns.Add("feederNumber", typeof(string));
            dtCode.Columns.Add("feederValue", typeof(string));
            dtCode.Columns.Add("feederPosX", typeof(double));
            dtCode.Columns.Add("feederPosY", typeof(double));
            dtCode.Columns.Add("feederPosZ", typeof(double));


            
        }

        private void POPFeedersTable()
        {
            ds.ReadXml(Path.Combine(Application.StartupPath, "feeders.xml"));
        }
        // generate gcode button
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.Cells[6].Value.ToString().Equals("0"))
                {
                    string RefDes = row.Cells[0].Value.ToString();
                    string ComponentType = row.Cells[0].Value.ToString();
                    double PosX = double.Parse(row.Cells[2].Value.ToString());
                    double PosY = double.Parse(row.Cells[3].Value.ToString());
                    int Rotate  = int.Parse(row.Cells[4].Value.ToString());
                    string Value = row.Cells[1].Value.ToString();
                    string feederNumber = GetfeederNumber(row.Cells[6].Value.ToString());
                    double feederPosX = GetfeederPosX(row.Cells[6].Value.ToString());
                    double feederPosY = GetfeederPosY(row.Cells[6].Value.ToString());
                    double feederPosZ = GetfeederPosZ(row.Cells[6].Value.ToString());
                    dtCode.Rows.Add(RefDes, ComponentType, PosX, PosY, Rotate, Value, feederNumber, feederPosX, feederPosY, feederPosZ);
                    
                }
            }

            dataGridView2.DataSource = dtCode;
            GenerateGCode();
           // textBoxGCode.Text = sb.ToString();
           // textBoxGCode.Text = "G01 X10 Y10 F300";
        }
        private void GenerateGCode()
        {
            StringBuilder sb = new StringBuilder();

            DataView dv = new DataView(dtCode);
            dv.Sort = "feederNumber ASC";

            sb.Append("F10000" + Environment.NewLine);
            sb.Append("G01 Z0 A0 B0 C0 X0 Y0" + Environment.NewLine);
            foreach (DataRowView drv in dv)
            {
                sb.Append("G01 X" + drv["feederPosX"].ToString() + "  Y" + drv["feederPosY"].ToString() + Environment.NewLine);
                sb.Append("M9000" + drv["feederValue"].ToString() + Environment.NewLine); // send feeder to position
                sb.Append("G01 Z" + drv["feederPosZ"].ToString() + "  M90100"  + Environment.NewLine); // go down and turn on suction
                sb.Append("G01 Z20 A" + drv["Rotate"].ToString() + Environment.NewLine);
                sb.Append("G01 X" + drv["PosX"].ToString() + "  Y" + drv["PosY"].ToString() + Environment.NewLine);
                sb.Append("G01 Z" + drv["feederPosZ"].ToString() + "  M90101" + Environment.NewLine); // go down and turn off suction
                sb.Append("G01 Z20" + Environment.NewLine);
            }

            textBoxGCode.Text = sb.ToString();
        }
        private string GetfeederNumber(string fid)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = '" + fid + "'";
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval =  dv[0][0].ToString();
            }
            dv.Dispose();
            return returnval;
        }
        private double GetfeederPosX(string fid)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = '" + fid + "'";
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0][2].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        private double GetfeederPosY(string fid)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = '" + fid + "'";
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0][3].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        private double GetfeederPosZ(string fid)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = '" + fid + "'";
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0][4].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        private void saveGCodeStripMenuItem_Click(object sender, EventArgs e)
        {
            // save gcode to file
            saveFileDialog1.Filter = "NC files|*.nc";
            saveFileDialog1.ShowDialog();
        }

        

        private void saveFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, textBoxGCode.Text);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // save gcode to file
            saveFileDialog1.Filter = "NC files|*.nc";
            saveFileDialog1.ShowDialog();
        }
    }
}
