using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNPControllerKFlop
{
    public class DataToMach3
    {
        DataTable dtCode = new DataTable();
        private ComponentFeeders feeders = new ComponentFeeders();
        private Components comp = new Components();

        public DataView ConvertToGCode(DataGridView dg, double BoardOffsetX, double BoardOffsetY)
        {
            dtCode.Clear();
            
            if (dtCode.Columns.Count <= 1)
            {
                dtCode.Columns.Add("RefDes", typeof(string));
                dtCode.Columns.Add("ComponentType", typeof(string));
                dtCode.Columns.Add("PosX", typeof(double));
                dtCode.Columns.Add("PosY", typeof(double));
                dtCode.Columns.Add("ComponentRotation", typeof(int));
                dtCode.Columns.Add("ComponentValue", typeof(string));
                dtCode.Columns.Add("feederNumber", typeof(int));
                dtCode.Columns.Add("Code", typeof(int));

                // components table
                dtCode.Columns.Add("ComponentHeight", typeof(double));
                dtCode.Columns.Add("DefaultRotation", typeof(double));
                dtCode.Columns.Add("VerifywithCamera", typeof(bool));
                dtCode.Columns.Add("TapeFeeder", typeof(bool));

                // feeder table values
               
                dtCode.Columns.Add("feederPosX", typeof(double));
                dtCode.Columns.Add("feederPosY", typeof(double));
                dtCode.Columns.Add("feederPosZ", typeof(double));
                dtCode.Columns.Add("PickPlusChipHeight", typeof(bool));
              

            }
            foreach (DataGridViewRow row in dg.Rows)
            {
                // only add checked rows
                DataGridViewCheckBoxCell cell = row.Cells["Pick"] as DataGridViewCheckBoxCell;
                if (cell.Value.ToString().Equals("True"))
             
                {
                    string RefDes = row.Cells[0].Value.ToString();
                    string ComponentType = row.Cells[0].Value.ToString();
                    double PosX = double.Parse(row.Cells[2].Value.ToString()) + BoardOffsetX;
                    double PosY = double.Parse(row.Cells[3].Value.ToString()) + BoardOffsetY;
                    int Rotate = int.Parse(row.Cells[4].Value.ToString());
                    string Value = row.Cells[1].Value.ToString();

                    int feederNumber = int.Parse(row.Cells[6].Value.ToString());
                    int Code = int.Parse(row.Cells[7].Value.ToString());

                    // components table
                    double ComponentHeight = comp.GetComponentsHeight(Code.ToString());
                    double DefaultRotation = comp.GetComponentsDefaultRotation(Code.ToString());
                    bool VerifywithCamera = comp.GetComponentVerifywithCamera(Code.ToString());
                    bool TapeFeeder = comp.GetComponentTapeFeeder(Code.ToString());

                    // feeder table values

                    double feederPosX = feeders.GetfeederPosX(feederNumber.ToString());
                    double feederPosY = feeders.GetfeederPosY(feederNumber.ToString());
                    double feederPosZ = comp.GetPickerHeight(Code.ToString());
                    bool PickPlusChipHeight = feeders.GetFeederPickPlusChipHeight(feederNumber.ToString());

                    dtCode.Rows.Add(RefDes, ComponentType, PosX, PosY, Rotate, Value, feederNumber, Code, ComponentHeight, DefaultRotation, VerifywithCamera, TapeFeeder, feederPosX, feederPosY, feederPosZ, PickPlusChipHeight);

                }
            }

            StringBuilder sb = new StringBuilder();

            DataView dv = new DataView(dtCode);
            dv.Sort = "feederNumber ASC";

            
            return dv;
        }
    }
}
