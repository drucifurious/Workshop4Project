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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
            private void PackagesBtn_Click(object sender, EventArgs e)
            {
                frmPackages p = new frmPackages();
                p.Show();
            }

            private void ProductsBtn_Click(object sender, EventArgs e)
            {
                frmProducts pr = new frmProducts();
                pr.Show();
            }

            private void SuppliersBtn_Click(object sender, EventArgs e)
            {
                frmSuppliers s = new frmSuppliers();
                s.Show();
            }

            private void ProdSuppBtn_Click(object sender, EventArgs e)
            {
                frmProductsSuppliers ps = new frmProductsSuppliers();
                ps.Show();
            }

            private void PackProdSuppBtn_Click(object sender, EventArgs e)
            {
                frmPackagesProductsSuppliers pps = new frmPackagesProductsSuppliers();
                pps.Show();
            }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
    }

