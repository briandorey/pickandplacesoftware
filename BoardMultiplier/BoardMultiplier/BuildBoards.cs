using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardMultiplier
{
    public class BuildBoards
    {
        DataTable dtCode = new DataTable();
       

        public string ConvertToData(DataView dvinput, double BoardOffsetX, double BoardOffsetY, int boardsX, int boardsY)
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append("RefDes,Type,X (mm),Y (mm),Side,Rotate,Value,Feeder,Code" + Environment.NewLine);
            // loop across Y axis
            for (int i = 1; i <= boardsY; i++)
            {

                for (int x = 1; x <= boardsX; x++)
                {
                    foreach (DataRowView drv in dvinput)
                    {
                        double newx = Double.Parse(drv["PosX"].ToString());
                        double newy = Double.Parse(drv["PosY"].ToString());
                        sb.Append(drv["RefDes"].ToString() + "," + drv["Type"].ToString() + "," + newx.ToString() + "," + newy.ToString() + "," + drv["Side"].ToString() + "," + drv["Rotate"].ToString() + "," + drv["Value"].ToString() + "," + drv["Feeder"].ToString() + "," + drv["Code"].ToString() + Environment.NewLine);
                    }
                }
            }
            return sb.ToString();
        }

        public double CalcNewXLocationValue(double BoardOffset, int currentrow, double currentval)
        {
            return ((BoardOffset * currentrow) + currentval);
        }
        

        /* 
         * 
         * dt.Columns.Add("RefDes", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("PosX", typeof(double));
            dt.Columns.Add("PosY", typeof(double));
            dt.Columns.Add("Side", typeof(string));
            dt.Columns.Add("Rotate", typeof(int));
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Feeder", typeof(int));
            dt.Columns.Add("Code", typeof(int));
         * */
    }
}
