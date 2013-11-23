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
    public class Components
    {
        private DataSet dscomponents = new DataSet();

        public DataSet POPComponentsTable()
        {
            FileStream finschema = new FileStream( System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\components.xsd", FileMode.Open, FileAccess.Read, FileShare.Read);
            dscomponents.ReadXmlSchema(finschema);
            finschema.Close();
            FileStream findata = new FileStream(Path.Combine(Application.StartupPath, "components.xml"), FileMode.Open,
                                 FileAccess.Read, FileShare.ReadWrite);
            dscomponents.ReadXml(findata);
            findata.Close();
            return dscomponents;
        }

        public string GetComponentValue(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval = dv[0]["ComponentValue"].ToString();
            }
            dv.Dispose();
            return returnval;
        }
        public string GetComponentPackage(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval = dv[0]["Package"].ToString();
            }
            dv.Dispose();
            return returnval;
        }
        public double GetComponentsHeight(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["ComponentHeight"].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public double GetPickerHeight(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["PickerHeight"].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public double GetComponentsDefaultRotation(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["DefaultRotation"].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        public bool GetComponentVerifywithCamera(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            bool returnval = false;
            if (dv.Count > 0)
            {
                if (dv[0]["VerifywithCamera"].ToString().Equals("True"))
                {
                    returnval = true;
                }
                else
                {
                    returnval = false;
                }
            }
            dv.Dispose();
            return returnval;
        }

        public bool GetComponentTapeFeeder(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            bool returnval = false;
            if (dv.Count > 0)
            {
                
                if (dv[0]["TapeFeeder"].ToString().Equals("True"))
                {
                    returnval = true;
                }
                else
                {
                    returnval = false;
                }
            }
            dv.Dispose();
            return returnval;
        }
    }
}
