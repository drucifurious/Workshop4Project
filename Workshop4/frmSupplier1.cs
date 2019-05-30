
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
    public partial class frmSupplier1 : Form
    {
        public frmSupplier1()
        {
            InitializeComponent();
        }

        private void frmSupplier1_Load_1(object sender, EventArgs e)
        {

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.GreenYellow;

            //dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 35;


            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Font
            // Dim font As New Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = font;

            dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.Height = 65;
            //label3.Text = dataGridView1.CurrentCell.Value.ToString();
            dataGridView1.DataSource = DataLayer.SupplierDB.orderby("SupplierId");

        }


        //let user sort table by supplier ID and Name
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string coluName = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = DataLayer.SupplierDB.orderby(coluName);
        }

        //display the detail of the selected recored
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
        }


        //add a new record
        private void Add_button_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("SupplierID  and shpplierName must be filled");
            }
            else
            {
                //catch error
                try
                {
                    int ID = Convert.ToInt32(textBox2.Text);
                    int qq1 = DataLayer.SupplierDB.AddSupplier(ID, textBox3.Text);
                    if (qq1 > 0)
                    {
                        MessageBox.Show("insert successful!");
                        dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
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

        //delete a selected record
        private void Delete_button_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            string ID1 = dataGridView1.Rows[index].Cells[0].Value.ToString();
            int ID = Convert.ToInt32(ID1);
            DialogResult dr = MessageBox.Show("Do you want to delete supplierID " + ID1 + " ?", "reminder", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Validate();
                try
                {
                    int qq1 = DataLayer.SupplierDB.DeleteSupplier(ID);

                    if (qq1 > 0)
                    {
                        MessageBox.Show("Delete successful!");
                        dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
                        if (index == dataGridView1.Rows.Count)
                        { dataGridView1.CurrentCell = dataGridView1.Rows[index - 1].Cells[0]; }
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
        private void update_button_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("SupplierID must be selected and shpplierName must be filled");
            }
            else
            {
                int qq1 = DataLayer.SupplierDB.UpdateSupplier(Convert.ToInt32(textBox4.Text), textBox5.Text);
                if (qq1 > 0)
                {
                    MessageBox.Show("Update successful!");
                    dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
                }
                else
                {
                    MessageBox.Show("Update not successful!,Make sure supplierID is correct");
                }

                //display the updated record              
                Supplier supp = new Supplier();
                int id = Convert.ToInt32(textBox4.Text);
                supp = DataLayer.SupplierDB.GetSuppliers(id);
                textBox4.Text = supp.SupplierId.ToString();
                textBox5.Text = supp.SupName;
                textBox7.Text = supp.SupplierId.ToString();
                textBox8.Text = supp.SupName;
                //locate cursor to updated record
                Locate(textBox4.Text);
            }
        }

        //display the detail of the selected record
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.SupplierDB.orderby("SupplierId");
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                // List<int> rowsOfInterest = new List<int>();
                Locate(textBox1.Text);
                textBox4.Text = dataGridView1.CurrentCell.Value.ToString();
                Supplier supp = new Supplier();
                int ID = Convert.ToInt32(textBox1.Text);
                supp = DataLayer.SupplierDB.GetSuppliers(ID);
                textBox4.Text = supp.SupplierId.ToString();
                textBox5.Text = supp.SupName;
                textBox7.Text = supp.SupplierId.ToString();
                textBox8.Text = supp.SupName;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.SupplierDB.orderby("SupName");
            Locate(textBox6.Text);
            int index = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox4.Text = textBox1.Text;
            textBox7.Text = textBox1.Text;

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            Locate(textBox4.Text);
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
            this.toolTip2.Show("you can find record by input supplier Name or click cell ", this.label1);
            this.toolTip2.IsBalloon = true;
            this.toolTip2.UseFading = true;

        }

        //give user a message when user leave cursor on label1
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.toolTip2.IsBalloon = false;
            this.toolTip2.UseFading = false;
        }

        //give user a message when user enter cursor on label5
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.Show("you can find record by input supplier ID or click cell ", this.label5);
            this.toolTip1.IsBalloon = true;
            this.toolTip1.UseFading = true;
        }

        //give user a message when user leave cursor on label5
        private void label5_MouseLeave(object sender, EventArgs e)
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

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            
        }

        //display the detail of the selected record
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //    dataGridView1.DataSource = DataLayer.SupplierDB.orderby("SupplierId");
        //    if (textBox1.Text == "")
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        // List<int> rowsOfInterest = new List<int>();
        //        Locate(textBox1.Text);
        //        textBox4.Text = dataGridView1.CurrentCell.Value.ToString();
        //        Supplier supp = new Supplier();
        //        int ID = Convert.ToInt32(textBox1.Text);
        //        supp = DataLayer.SupplierDB.GetSuppliers(ID);
        //     
        //        label4.Text = supp.SupName;
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}




















