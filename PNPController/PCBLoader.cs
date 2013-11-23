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
    public class PCBLoader
    {
        
        DataTable dt = new DataTable();
        private DataSet dscomponents = new DataSet();


        public void SetupGridView(System.Windows.Forms.DataGridView dg)
        {

            
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

            DataGridViewTextBoxColumn dgvc7= new DataGridViewTextBoxColumn();
            dgvc7.DataPropertyName = "feederNumber";
            dgvc7.HeaderText = "Feeder Number";
            dgvc7.ReadOnly = true;
            dg.Columns.Add(dgvc7);

            DataGridViewTextBoxColumn dgvc8 = new DataGridViewTextBoxColumn();
            dgvc8.DataPropertyName = "ComponentCode";
            dgvc8.HeaderText = "Code";
            dgvc8.ReadOnly = true;
            dg.Columns.Add(dgvc8);

            DataGridViewCheckBoxColumn dgv9 = new DataGridViewCheckBoxColumn();
            dgv9.HeaderText = "Pick";
            dgv9.Name = "Pick";
            dgv9.ReadOnly = false;
            dg.Columns.Add(dgv9);
          
            dg.AutoResizeColumns();
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

           // POPDataTable();
        }

        public DataSet LoadPCB(string file, System.Windows.Forms.DataGridView dg)
        {
            dt.Clear();
            try
            {
                dscomponents.Tables.RemoveAt(0);
            }
            catch { }
            try { 
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

            /*
            try
            {
                string text = File.ReadAllText(file);
                int counter = 1;
                string[] sites = text.Split('\n');
                if (sites.Length <= 1)
                {
                    MessageBox.Show(DateTime.Now.ToString() + " Empty Data File");

                }
                else
                {
                   
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
                          //  MessageBox.Show("CSV stock data has missing rows or data: " + names.Length);
                        }
                        else
                        {
                            if (!names[0].ToString().Equals("RefDes"))
                            {
                                dt.Rows.Add(names[0].ToString(), // RefDes
                                    names[1].ToString(), // Type
                                    Double.Parse(names[3].ToString()), //PosX
                                    Double.Parse(names[2].ToString()), //PosY
                                    Int32.Parse(names[5].ToString()), //Rotate
                                    names[6].ToString(), //Value
                                    Int32.Parse(names[7].ToString()), //feederNumber
                                    Int32.Parse(names[8].ToString())); //Component Code
                               
                            }
                            counter++;
                        }

                    }
                }


            }
            catch (IOException)
            {
            }
            

            foreach (DataTable dtnew in dscomponents.Tables)
              {
                  MessageBox.Show(dtnew.TableName);
                  string rowcount = dscomponents.Tables[dtnew.TableName].Rows.Count.ToString();
                  MessageBox.Show(rowcount);
              }
             * */  
            //MessageBox.Show(dscomponents.Tables.Count.ToString());
           // dscomponents.Tables
           
            DataView dvTable = new DataView(dscomponents.Tables["Component"]);
            dvTable.Sort = "feederNumber ASC";
            dg.DataSource = dvTable;

            for (int i = 0; i < dg.Rows.Count; i++)
            {
                dg.Rows[i].Cells["Pick"].Value = true;
            }
            return dscomponents;

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
            dt.Columns.Add("ComponentCode", typeof(byte));
           
        }
        
    }
}
