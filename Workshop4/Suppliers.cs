using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;

namespace Workshop4
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Text);
            Supplier supp = new Supplier();
            supp = DataLayer.SupplierDB.GetSupplier(ID);

            label3.Text = supp.SupplierId.ToString();
            label4.Text = supp.SupName;
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.SupplierDB.GetSupplier();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
