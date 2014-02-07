using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNPController
{
    public class DataToMach3
    {
        DataTable dtCode = new DataTable();
        private ComponentFeeders cf = new ComponentFeeders();

        public string ConvertToGCode(DataGridView dg, double BoardOffsetX, double BoardOffsetY, string FeedSpeed)
        {
            dtCode.Clear();
            
            if (dtCode.Columns.Count <= 1)
            {
                dtCode.Columns.Add("RefDes", typeof(string));
                dtCode.Columns.Add("ComponentType", typeof(string));
                dtCode.Columns.Add("PosX", typeof(double));
                dtCode.Columns.Add("PosY", typeof(double));
                dtCode.Columns.Add("FeederRotate", typeof(int));
                dtCode.Columns.Add("Value", typeof(string));
                dtCode.Columns.Add("feederNumber", typeof(byte));
                dtCode.Columns.Add("feederPosX", typeof(double));
                dtCode.Columns.Add("feederPosY", typeof(double));
                dtCode.Columns.Add("feederPosZ", typeof(double));

                dtCode.Columns.Add("ComponentHeight", typeof(double));
                dtCode.Columns.Add("VerifywithCamera", typeof(int));
                dtCode.Columns.Add("FeederActivationCode", typeof(string));

            }
            foreach (DataGridViewRow row in dg.Rows)
            {
                if (!row.Cells[6].Value.ToString().Equals("0"))
                {
                    string RefDes = row.Cells[0].Value.ToString();
                    string ComponentType = row.Cells[0].Value.ToString();
                    double PosX = double.Parse(row.Cells[2].Value.ToString()) + BoardOffsetX;
                    double PosY = double.Parse(row.Cells[3].Value.ToString()) + BoardOffsetY;
                    
                    int Rotate = int.Parse(row.Cells[4].Value.ToString());
                    string Value = row.Cells[1].Value.ToString();
                    string feederNumber = cf.GetfeederNumber(row.Cells[6].Value.ToString());
                    double feederPosX = cf.GetfeederPosX(row.Cells[6].Value.ToString());
                    double feederPosY = cf.GetfeederPosY(row.Cells[6].Value.ToString());
                    double feederPosZ = cf.GetfeederPosZ(row.Cells[6].Value.ToString());
                    double ComponentHeight = cf.GetfeederComponentHeight(row.Cells[6].Value.ToString());
                    int VerifywithCamera = cf.GetfeederVerifywithCamera(row.Cells[6].Value.ToString());
                    string FeederActivationCode = cf.GetfeederActivationCode(row.Cells[6].Value.ToString());
                    //MessageBox//MessageBox.Show(ComponentHeight.ToString());


                    dtCode.Rows.Add(RefDes, ComponentType, PosX, PosY, Rotate, Value, feederNumber, feederPosX, feederPosY, feederPosZ, ComponentHeight, VerifywithCamera, FeederActivationCode);

                }
            }

            StringBuilder sb = new StringBuilder();

            DataView dv = new DataView(dtCode);
            dv.Sort = "feederNumber ASC";

            sb.Append("F" + FeedSpeed + Environment.NewLine);
            sb.Append("G01 Z0 A0 B0 C0 X0 Y0" + Environment.NewLine);
            foreach (DataRowView drv in dv)
            {
                sb.Append(drv["FeederActivationCode"].ToString() + " (" + drv["ComponentType"].ToString() + " " + drv["Value"].ToString() + ")" + Environment.NewLine); // send feeder to position
                sb.Append("G01 X" + drv["feederPosX"].ToString() + "  Y" + drv["feederPosY"].ToString() + Environment.NewLine);

                sb.Append("G01 Z" + drv["feederPosZ"].ToString() + "  M90001" + Environment.NewLine); // go down and turn on suction
                sb.Append("G01 Z20 B" + drv["FeederRotate"].ToString() + Environment.NewLine);
                sb.Append("G01 X" + drv["PosX"].ToString() + "  Y" + drv["PosY"].ToString() + Environment.NewLine);
                sb.Append("G01 Z" + drv["ComponentHeight"].ToString() + "  M90000" + Environment.NewLine); // go down and turn off suction
                sb.Append("G01 Z20" + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
