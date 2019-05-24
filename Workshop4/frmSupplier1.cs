using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
namespace Workshop4
{
    public partial class frmSupplier1 : Form
    {
        public frmSupplier1()
        {
            InitializeComponent();
        }

        private void frmSupplier1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentCell.Value.ToString();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Text);
            Supplier supp = new Supplier();
            supp = DataLayer.SupplierDB.GetSuppliers(ID);

            label1.Text = supp.SupplierId.ToString();
            label2.Text = supp.SupName;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
