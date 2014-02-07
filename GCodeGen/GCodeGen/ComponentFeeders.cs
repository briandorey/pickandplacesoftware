using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PNPController
{
    public class ComponentFeeders
    {
        public DataSet ds = new DataSet();
       

        public DataSet POPFeedersTable()
        {
            FileStream finschema = new FileStream( System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\feeders.xsd", FileMode.Open, FileAccess.Read, FileShare.Read);

            //Read the Schema into the DataSet
            ds.ReadXmlSchema(finschema);

            //Close the FileStream
            finschema.Close();

            //Create a FileStream to the Xml Database file in Read mode
            FileStream findata = new FileStream(Path.Combine(Application.StartupPath, "feeders.xml"), FileMode.Open,
                                 FileAccess.Read, FileShare.ReadWrite);

            //Read the DataBase into the DataSet
            ds.ReadXml(findata);

            //Close the FileStream
            findata.Close();
            return ds;
        }

        public string GetfeederNumber(string fid)
        {
            if (ds.Tables.Count == 0)
            {
                POPFeedersTable();
            }
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = " + fid;
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval = dv[0][0].ToString();
            }
            dv.Dispose();
            return returnval;
        }
        public double GetfeederPosX(string fid)
        {
            if (ds.Tables.Count == 0)
            {
                POPFeedersTable();
            }
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0][2].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public double GetfeederPosY(string fid)
        {
            if (ds.Tables.Count == 0)
            {
                POPFeedersTable();
            }
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0][3].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public double GetfeederPosZ(string fid)
        {
            if (ds.Tables.Count == 0)
            {
                POPFeedersTable();
            }
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0][4].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        public double GetfeederComponentHeight(string fid)
        {
            if (ds.Tables.Count == 0)
            {
                POPFeedersTable();
            }
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["ComponentHeight"].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        public int GetfeederVerifywithCamera(string fid)
        {
            if (ds.Tables.Count == 0)
            {
                POPFeedersTable();
            }
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = " + fid;
            int returnval = 0;
            if (dv.Count > 0)
            {
                if (dv[0]["VerifywithCamera"].ToString().Equals("true")) {
                    returnval = 1;
                } else {
                    returnval = 0;
                }
     
            }
            dv.Dispose();
            return returnval;
        }

        public string GetfeederActivationCode(string fid)
        {
            if (ds.Tables.Count == 0)
            {
                POPFeedersTable();
            }
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "feederNumber = " + fid;
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval =dv[0]["FeederActivationCode"].ToString();
            }
            dv.Dispose();
            return returnval;
        }
    }
}
