using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Windows.Forms;


namespace BoardMultiplier
{
    public class CSVLoader
    {
        // Loads CVS file with board component location data into a datatable and returns a DataView sorted by Feeder
        DataTable dt = new DataTable();

        public DataView LoadCSV(string file)
        {
            POPDataTable();
            dt.Clear();

            try
            {
                string text = File.ReadAllText(file);

                int counter = 1;
                string[] sites = text.Split('\n');
                if (sites.Length > 1)
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
                        if (names.Length > 1)
                        {
                            if (!names[0].ToString().Equals("RefDes"))
                            {
                                dt.Rows.Add(names[0].ToString(), // RefDes
                                names[1].ToString(), // Type
                                Double.Parse(names[2].ToString()), //PosX
                                Double.Parse(names[3].ToString()), //PosY
                                names[4].ToString(), //Side
                                Int32.Parse(names[5].ToString()), //Rotate
                                names[6].ToString(), //Value
                                Int32.Parse(names[7].ToString()), //Feeder
                                Int32.Parse(names[8].ToString())); ; //Code
                            }
                            counter++;
                        }

                    }
                }


            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DataView dvTable = new DataView(dt);
            dvTable.Sort = "Feeder ASC";
            return dvTable;
        }



        private void POPDataTable()
        {
            dt.Columns.Add("RefDes", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("PosX", typeof(double));
            dt.Columns.Add("PosY", typeof(double));
            dt.Columns.Add("Side", typeof(string));
            dt.Columns.Add("Rotate", typeof(int));
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Feeder", typeof(int));
            dt.Columns.Add("Code", typeof(int));
        }

    }
}
