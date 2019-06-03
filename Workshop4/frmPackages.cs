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
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.OldLace;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;


            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 35;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          
            dataGridView1.DataSource = DataLayer.PackageDB.GetPackages();
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.Height = 65;
            
           dataGridView1.DataSource = DataLayer.PackageDB.orderby("PackageId");
            dataGridView2.DataSource = DataLayer.ProductDB.GetProduct();
            dataGridView3.DataSource = DataLayer.Product_SuppliersDB.GetProduct_Suppliers();
            dataGridView3.DataSource = DataLayer.Product_SuppliersDB.orderby("ProductId");


        }


        //-----------------------------------------------------------------------------------------------------
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //let user sort table by supplier ID and Name
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string coluName = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = DataLayer.PackageDB.orderby(coluName);

        }

 
        
        // Add the Record
        private void Add_button_Click(object sender, EventArgs e)
        {

            if ( txtPkName1.Text == ""||txtDescription1.Text=="")
            {
                MessageBox.Show("Package Name and Package Description cannot be null");
            }
            else
            {
                //catch error
                try
                {
                    //int ID = Convert.ToInt32(txtPkId1.Text);
                    DateTime StartDate = Convert.ToDateTime(txtStartDate1.Text);
                    DateTime EndDate = Convert.ToDateTime(txtEndDate1.Text);
                    double BasePrice = Convert.ToDouble(txtBasePrice1.Text);
                    double AgencyCommission = Convert.ToDouble(txtAgencyCommission.Text);
                    if (EndDate < StartDate || AgencyCommission > BasePrice)
                    {
                        MessageBox.Show("the Package End Date must be later than Package Start Date " +
                              "  and the Agency Commission cannot be greater than the Base Price");
                        return;
                    }
                    else            
                    {
                        int qq1 = DataLayer.PackageDB.AddPackage(txtPkName1.Text, StartDate, EndDate, txtDescription1.Text, BasePrice, AgencyCommission);
                        if (qq1 > 0)
                        {
                            MessageBox.Show("insert successful!");
                            dataGridView1.DataSource = DataLayer.PackageDB.GetPackages();
                        }
                        else
                        { MessageBox.Show("insert not successful!"); }
                        int i = dataGridView1.Rows.Count - 1;
                        dataGridView1.CurrentCell = dataGridView1[0, i];
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                    return;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error #" + ex.Number + ":" + ex.Message, ex.GetType().ToString());
                    return;
                }

            }


        }
        // Delete the Record
        private void Delete_button_Click_1(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            string ID1 = dataGridView1.Rows[index].Cells[0].Value.ToString();
            int ID = Convert.ToInt32(ID1);
            DialogResult dr = MessageBox.Show("Do you want to delete Package ID " + ID1 + " ?", "reminder", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Validate();
                try
                {
                    int qq1 = DataLayer.PackageDB.DelePackage(ID);

                    if (qq1 > 0)
                    {
                        MessageBox.Show("Delete successful!");
                        dataGridView1.DataSource = DataLayer.PackageDB.GetPackages();
                        if (index == dataGridView1.Rows.Count)
                        { dataGridView1.CurrentCell = dataGridView1.Rows[index-1].Cells[0]; }
                        else
                        { dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0]; }
                    }
                    else
                    {
                        MessageBox.Show("Delete not successful!");
                    }

                }

                //catch error
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                    return;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error #" + ex.Number + ":" + ex.Message, ex.GetType().ToString());
                    return;
                }
            }
        }

        //update a selected record
        private void update_button_Click_1(object sender, EventArgs e)
        {
           
        }
        private void update_button_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            txtPackId2.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            if (txtPackId2.Text == "")
            {
                MessageBox.Show("Package ID must  be filled");
            }
            else
            {
                DateTime StartDate = Convert.ToDateTime(txtStartDate2.Text);
                DateTime EndDate = Convert.ToDateTime(txtEndDate2.Text);
                double BasePrice = Convert.ToDouble(txtBasePrice2.Text);
                double AgencyCommission = Convert.ToDouble(txtAgencyComm2.Text);
                int qq1 = DataLayer.PackageDB.UpdaPackage (Convert.ToInt32(txtPackId2.Text),  txtPackName2.Text, StartDate, EndDate, txtDescription2.Text, BasePrice, AgencyCommission);
                if (qq1 > 0)
                {
                    MessageBox.Show("Update successful!");
                    dataGridView1.DataSource = DataLayer.PackageDB.GetPackages();
                }
                else
                {
                    MessageBox.Show("Update not successful!,Make sure Package ID is correct");
                }

                //display the updated record              
                Packages pk = new Packages();
                int id = Convert.ToInt32(txtPackId2.Text);
          
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            txtPackId2.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();

            txtPackName2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtStartDate2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtEndDate2.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtDescription2.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            txtBasePrice2.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            txtAgencyComm2.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();


        

       
        }

        private void txtAdd_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = true;
        }

        private void txtUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Visible = true;
        }

        private void txtDelete_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Visible = true;
        }

        private void txtHide1_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = false;
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Visible = false;
        }

        private void textBox19_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Visible = false;
        }

      
    }

        }
   


       