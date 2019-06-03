using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop4
{
    public partial class frmPackagesProductsSuppliers : Form
    {
        public frmPackagesProductsSuppliers()
        {
            InitializeComponent();
        }

        private void PackagesProductsSuppliers_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.OldLace;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            //dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 35;


            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Font
            // Dim font As New Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = font;

            dataGridView1.DataSource = DataLayer.Packages_products_suppliersDB.GetPackages_products_suppliers ();
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.Height = 65;
            //label3.Text = dataGridView1.CurrentCell.Value.ToString();
           // dataGridView1.DataSource = DataLayer.Packages_products_suppliersDB.O("SupplierId");

        }
    }
}
