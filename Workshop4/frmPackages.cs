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
using DataLayer;
using System.Data.SqlClient;


namespace Workshop4
{
    public partial class frmPackages : Form
    {
        public frmPackages()
        {
            InitializeComponent();
        }

        private void Packages_Load(object sender, EventArgs e)
        {

        }

        //let user sort table by supplier ID and Name
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //string coluName = comboBox1.SelectedItem.ToString();
            //dataGridView1.DataSource = DataLayer.PackageDB.orderby(coluName);
        }

        //display the detail of the selected recored
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = dataGridView1.CurrentCell.RowIndex;
            //txtPackageId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            //txtPkgName.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
        }


        //add a new record
        private void Add_button_Click_1(object sender, EventArgs e)
        {

        }

        //delete a selected record
        private void Delete_button_Click(object sender, EventArgs e)
        {

        }


        //update a selected record
        private void update_button_Click(object sender, EventArgs e)
        {

        }

        //display the detail of the selected record
        private void textBox1_TextChanged(object sender, EventArgs e)

        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            //Locate(textBox4.Text);
        }

        


        //give user a message when user enter cursor on label1
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            //this.toolTip2.Show("you can find record by input supplier Name or click cell ", this.label1);
            //this.toolTip2.IsBalloon = true;
            //this.toolTip2.UseFading = true;

        }

        //give user a message when user leave cursor on label1
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            //this.toolTip2.IsBalloon = false;
            //this.toolTip2.UseFading = false;
        }

        //give user a message when user enter cursor on label5
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            //this.toolTip1.Show("you can find record by input supplier ID or click cell ", this.PkName);
            //this.toolTip1.IsBalloon = true;
            //this.toolTip1.UseFading = true;
        }

        //give user a message when user leave cursor on label5
        private void label5_MouseLeave(object sender, EventArgs e)
        {
            //this.toolTip1.IsBalloon = false;
            //this.toolTip1.UseFading = false;
        }



        //let user go back home page
        private void go_home_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Home h1 = new Home();
            h1.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string coluName = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = DataLayer.PackageDB.orderby(coluName);

        }

        private void txtPackageId_TextChanged(object sender, EventArgs e)
        {

            {
                dataGridView1.DataSource = DataLayer.SupplierDB.orderby("SupplierId");
                if (txtPackageId.Text == "")
                {
                    return;
                }
                else
                {
                    // List<int> rowsOfInterest = new List<int>();
                    Locate(txtPackageId.Text);
                    // textBox4.Text = dataGridView1.CurrentCell.Value.ToString();
                    Supplier supp = new Supplier();
                    int ID = Convert.ToInt32(txtPackageId.Text);
                    supp = DataLayer.SupplierDB.GetSuppliers(ID);
                    label3.Text = supp.SupplierId.ToString();
                    lblPkID.Text = supp.SupName;
                }
            }

        }
            private void txtPkgName_TextChanged(object sender, EventArgs e)
            {
                dataGridView1.DataSource = DataLayer.SupplierDB.orderby("SupName");
                //Locate(textBox6.Text);
                int index = dataGridView1.CurrentCell.RowIndex;
                txtPackageId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
               // textBox4.Text = txtPackageId.Text;
            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                txtPackageId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txtPkgName.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Locate(txtPkName2.Text);
        }

        //method for locate selected record in the table
        public void Locate(string keyword)

        {
            if (keyword == "")
            {
                return;
            }
            else
            {
                int row = dataGridView1.Rows.Count;
                int cell = dataGridView1.Rows[1].Cells.Count;
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < cell; j++)
                    {
                        //if  (dataGridView1.Rows[i].Cells[j].Value.ToString().Trim()==(keyword.Trim()))
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Trim().StartsWith(keyword.Trim()))
                        {
                            dataGridView1.CurrentCell = dataGridView1[j, i];
                            dataGridView1.Rows[i].Selected = true;
                            int index = dataGridView1.CurrentCell.RowIndex;
                            dataGridView1.FirstDisplayedScrollingRowIndex = index;
                            i = i + 1;
                            return;
                        }
                    }
                }

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void PkName_Click(object sender, EventArgs e)
        {

        }
    }
    }
