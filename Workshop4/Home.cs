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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void PackagesBtn_Click(object sender, EventArgs e)
        {
            Packages p = new Packages();
            p.Show();
        }

        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            Products pr = new Products();
            pr.Show();
        }

        private void SuppliersBtn_Click(object sender, EventArgs e)
        {
            Suppliers s = new Suppliers();
            s.Show();
        }

        private void ProdSuppBtn_Click(object sender, EventArgs e)
        {
            ProductsSuppliers ps = new ProductsSuppliers();
            ps.Show();
        }

        private void PackProdSuppBtn_Click(object sender, EventArgs e)
        {
            PackagesProductsSuppliers pps = new PackagesProductsSuppliers();
            pps.Show();
        }
    }
}
