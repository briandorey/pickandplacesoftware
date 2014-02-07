using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Windows.Forms;


namespace PNPController
{
    public class CSVLoader
    {
        private DataSet dsFeeders;

        DataTable dt = new DataTable();

        DataTable dtFeeders = new DataTable();
        DataTable dtCode = new DataTable();

       
        private ComponentFeeders cf = new ComponentFeeders();
        
        


        public void SetupGridView(System.Windows.Forms.DataGridView dg)
        {
            
            dsFeeders = cf.POPFeedersTable();
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;

            dg.AutoGenerateColumns = false;



            DataGridViewTextBoxColumn dgvc1 = new DataGridViewTextBoxColumn();
            dgvc1.DataPropertyName = "RefDes";
            dgvc1.HeaderText = "RefDes";
            dgvc1.ReadOnly = true;
            dg.Columns.Add(dgvc1);

            DataGridViewTextBoxColumn dgvc2 = new DataGridViewTextBoxColumn();
            dgvc2.DataPropertyName = "Type";
            dgvc2.HeaderText = "Type";
            dgvc2.ReadOnly = true;
            dg.Columns.Add(dgvc2);

            DataGridViewTextBoxColumn dgvc3 = new DataGridViewTextBoxColumn();
            dgvc3.DataPropertyName = "PosX";
            dgvc3.HeaderText = "PosX";
            dgvc3.ReadOnly = true;
            dg.Columns.Add(dgvc3);

            DataGridViewTextBoxColumn dgvc4 = new DataGridViewTextBoxColumn();
            dgvc4.DataPropertyName = "PosY";
            dgvc4.HeaderText = "PosY";
            dgvc4.ReadOnly = true;
            dg.Columns.Add(dgvc4);

            DataGridViewTextBoxColumn dgvc5 = new DataGridViewTextBoxColumn();
            dgvc5.DataPropertyName = "Rotate";
            dgvc5.HeaderText = "Rotate";
            dgvc5.ReadOnly = true;
            dg.Columns.Add(dgvc5);

            DataGridViewTextBoxColumn dgvc6 = new DataGridViewTextBoxColumn();
            dgvc6.DataPropertyName = "Value";
            dgvc6.HeaderText = "Value";
            dgvc6.ReadOnly = true;
            dg.Columns.Add(dgvc6);

            DataGridViewComboBoxColumn ColumnItem = new DataGridViewComboBoxColumn();


            ColumnItem.HeaderText = "Feeder Number";
            ColumnItem.Width = 120;
            ColumnItem.DataSource = dsFeeders.Tables[0].DefaultView;
            ColumnItem.DataPropertyName = "feederNumber";
            ColumnItem.ValueMember = "feederNumber";
            ColumnItem.DisplayMember = "feederValue";

            ColumnItem.ValueType = typeof(byte);

            dg.Columns.Add(ColumnItem);

            dg.AutoResizeColumns();
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            POPDataTable();
        }

        public void LoadCSV(string file, System.Windows.Forms.DataGridView dg)
        {
            dt.Clear();
            dtCode.Clear();
            try
            {
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
                                dt.Rows.Add(names[0].ToString(), // RefDes
                                    names[1].ToString(), // Type
                                    Double.Parse(names[2].ToString()), //PosX
                                    Double.Parse(names[3].ToString()), //PosY
                                    Int32.Parse(names[5].ToString()), //Rotate
                                    names[6].ToString(), //Value
                                    byte.Parse(names[7].ToString())); //feederNumber

                                // MessageBox.Show(names[7].ToString());
                                //names[6].ToString());
                            }
                            counter++;
                        }

                    }
                }


            }
            catch (IOException)
            {
            }

            DataView dvTable = new DataView(dt);
            dvTable.Sort = "feederNumber ASC";
            dg.DataSource = dvTable;


            //   MessageBox.Show(this.dataGridView1.Rows[0].Cells[6].ValueType.ToString());



        }



        private void POPDataTable()
        {
            
            

            dt.Columns.Add("RefDes", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("PosX", typeof(double));
            dt.Columns.Add("PosY", typeof(double));
            dt.Columns.Add("Rotate", typeof(int));
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("feederNumber", typeof(byte));

            dtCode.Columns.Add("RefDes", typeof(string));
            dtCode.Columns.Add("ComponentType", typeof(string));
            dtCode.Columns.Add("PosX", typeof(double));
            dtCode.Columns.Add("PosY", typeof(double));
            dtCode.Columns.Add("FeederRotate", typeof(int));
            dtCode.Columns.Add("Value", typeof(string));
            dtCode.Columns.Add("feederNumber", typeof(byte));
            dtCode.Columns.Add("feederValue", typeof(string));
            dtCode.Columns.Add("feederPosX", typeof(double));
            dtCode.Columns.Add("feederPosY", typeof(double));
            dtCode.Columns.Add("feederPosZ", typeof(double));



        }
        
    }
}
