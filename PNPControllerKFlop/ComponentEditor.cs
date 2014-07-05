using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNPControllerKFlop
{
    public partial class ComponentEditor : Form
    {
        public ComponentEditor()
        {
            InitializeComponent();
        }
        private DataSet dscomponents = new DataSet();

        public DataSet POPComponentsTable()
        {
            FileStream finschema = new FileStream(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\components.xsd", FileMode.Open, FileAccess.Read, FileShare.Read);
            dscomponents.ReadXmlSchema(finschema);
            finschema.Close();
            FileStream findata = new FileStream(Path.Combine(Application.StartupPath, "components.xml"), FileMode.Open,
                                 FileAccess.Read, FileShare.ReadWrite);
            dscomponents.ReadXml(findata);
            findata.Close();
            return dscomponents;
        }
       
        private void ComponentEditor_Load(object sender, EventArgs e)
        {
            dataGridViewComponents.DataSource = POPComponentsTable().Tables[0];
            dataGridViewComponents.AutoResizeColumns();
            dataGridViewComponents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewComponents.AllowUserToAddRows = true;
            dataGridViewComponents.AllowUserToDeleteRows = true;
            dataGridViewComponents.ReadOnly = false;
        }

       

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            dscomponents.Tables.RemoveAt(0);
            dataGridViewComponents.DataSource = null;

            dataGridViewComponents.DataSource = POPComponentsTable().Tables[0];
            dataGridViewComponents.AutoResizeColumns();
            dataGridViewComponents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewComponents.AllowUserToAddRows = true;
            dataGridViewComponents.AllowUserToDeleteRows = true;
            dataGridViewComponents.ReadOnly = false;
            MessageBox.Show("Component List Reloaded");
        }
    }
}
