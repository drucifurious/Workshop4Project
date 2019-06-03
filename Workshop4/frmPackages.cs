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
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;


            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 35;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          
            dataGridView1.DataSource = DataLayer.PackageDB.GetPackages();
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.Height = 65;
            
           dataGridView1.DataSource = DataLayer.PackageDB.orderby("PackageId");

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

        //display the detail of the selected recored in Grid View
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        
        // Add the Record
        private void Add_button_Click(object sender, EventArgs e)
        {

            if ( txtPkName1.Text == ""|| txtStartDate1.Text=="" || txtEndDate1.Text=="" ||txtDescription1.Text==""|| txtBasePrice1.Text==""|| txtAgencyCommission.Text=="")
            {
                MessageBox.Show("All Fields must be filled");
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

                    int qq1 = DataLayer.PackageDB.AddPackage(txtPkName1.Text,StartDate, EndDate, txtDescription1.Text, BasePrice, AgencyCommission);
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
                DateTime EndDate = Convert.ToDateTime(txtStartDate2.Text);
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
                int id = Convert.ToInt32(lblPakID.Text);
                pk = DataLayer.PackageDB.GetPackage(id);
                lblPakID.Text = pk.PackageId.ToString();
                lblPackageName.Text = pk.PkgName;
                lblPackageName.BackColor = System.Drawing.Color.LightBlue;
                //locate cursor to updated record
                Locate(lblPakID.Text);
            }
        }
            //display the detail of the selected record
            private void txtPackageId_TextChanged(object sender, EventArgs e)
        {

            {
                dataGridView1.DataSource = DataLayer.PackageDB.orderby("PackageId");
                if (txtPackageId.Text == "")
                {
                    return;
                }
                else
                {
                    // List<int> rowsOfInterest = new List<int>();\
                    Locate(txtPackageId.Text);
                    // textBox4.Text = dataGridView1.CurrentCell.Value.ToString();
                    Packages pk = new Packages();
                    int ID = Convert.ToInt32(txtPackageId.Text);
                    pk = DataLayer.PackageDB.GetPackage (ID);
                    lblPakID.Text = pk.PackageId.ToString();
                    txtPkgName.Text = pk.PkgName;
                }
            }

        }
       
        private void txtPakName_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.PackageDB.orderby("PkgName");
            Locate(txtPackageId.Text);
            int index = dataGridView1.CurrentCell.RowIndex;
            txtPackageId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
             txtPkId1.Text = txtPackageId.Text;
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
        //give user a message when user enter cursor on label1
        private void label1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        //give user a message when user leave cursor on label1
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        //give user a message when user enter cursor on label5
        private void label5_MouseEnter(object sender, EventArgs e)
        {

        }

        //give user a message when user leave cursor on label5
        private void label5_MouseLeave(object sender, EventArgs e)
        {
           
        }
        private void lblPkID_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.Show("you can find record by input supplier ID or click cell ", this.lblPkID);
            this.toolTip1.IsBalloon = true;
            this.toolTip1.UseFading = true;
        }
        private void PkName_MouseEnter(object sender, EventArgs e)
        {

            this.toolTip2.Show("you can find record by input supplier Name or click cell ", this.PkName);
            this.toolTip2.IsBalloon = true;
            this.toolTip2.UseFading = true;
        }

        private void PkName_MouseLeave(object sender, EventArgs e)
        {
            this.toolTip2.IsBalloon = false;
            this.toolTip2.UseFading = false;
        }

        

        private void lblPkID_MouseLeave(object sender, EventArgs e)
        {
            this.toolTip1.IsBalloon = false;
            this.toolTip1.UseFading = false;

        }



        //let user go back home page
        private void go_home_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Home h1 = new Home();
            h1.Show();
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

        private void txtPkId2(object sender, KeyEventArgs e)
        {

        }

        private void txtHide1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;



        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAdd_TextChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void txtUpdate_TextChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }
    }
    }
