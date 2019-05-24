
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
            dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string coluName = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = DataLayer.SupplierDB.orderby(coluName);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
        }


        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
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
                        if (textBox1.Text.Trim() == dataGridView1.Rows[i].Cells[j].Value.ToString().Trim())
                        {

                            dataGridView1.CurrentCell = dataGridView1[j, i];
                            dataGridView1.Rows[i].Selected = true;
                            i = i + 1;
                            return;
                        }
                    }
                }




            }
        }        
   








        private void Add_button_Click_1(object sender, EventArgs e)
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

        private void Delete_button_Click(object sender, EventArgs e)
        {
            Delete_button.BackColor = System.Drawing.Color.LightBlue;
            DialogResult dr = MessageBox.Show("Do you want to delete?", "reminder", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {


                int ID = Convert.ToInt32(dataGridView1.CurrentCell.Value.ToString());
                int qq1 = DataLayer.SupplierDB.DeleteSupplier(ID);

                if (qq1 > 0)
                {
                    MessageBox.Show("Delete successful!");
                    dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
                }
                else
                { MessageBox.Show("Delete not successful!"); }
            }
        }




        private void label5_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.Show("you can find record by input supplier ID or click cell ", this.label5);
            this.toolTip1.IsBalloon = true;
            this.toolTip1.UseFading = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "")
            {
                //MessageBox.Show("can not be empty");
                return;
            }
            else
            {
                int row = dataGridView1.Rows.Count;
                int cell = dataGridView1.Rows[1].Cells.Count;
                int qq = 0;
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < cell; j++)
                    {
                        if (textBox1.Text.Trim() == dataGridView1.Rows[i].Cells[j].Value.ToString().Trim())
                        {

                            qq = 1;
                            dataGridView1.CurrentCell = dataGridView1[j, i];
                            dataGridView1.Rows[i].Selected = true;
                            i = i + 1;
                            return;
                        }
                    }
                    textBox4.Text = dataGridView1.CurrentCell.Value.ToString();
                    
                }

                //if (qq == 0)
                //{
                //    MessageBox.Show("others");
                //}

            }


        }

        private void go_home_button_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int ID = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString());

            textBox4.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            int qq1 = DataLayer.SupplierDB.UpdateSupplier(Convert.ToInt32(textBox4.Text), textBox5.Text);
            if (qq1 > 0)
            {
                MessageBox.Show("Update successful!");
                dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
            }
            else
            {
                MessageBox.Show("Update not successful!");
            }
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();

            textBox4.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            label4.BackColor = System.Drawing.Color.LightBlue;
            Supplier supp = new Supplier();
            int id = Convert.ToInt32(textBox4.Text);
            supp = DataLayer.SupplierDB.GetSuppliers(id);
            label3.Text = supp.SupplierId.ToString();
            label4.Text = supp.SupName;


            int row = dataGridView1.Rows.Count;
            int cell = dataGridView1.Rows[1].Cells.Count;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cell; j++)
                {
                    if (textBox1.Text.Trim() == dataGridView1.Rows[i].Cells[j].Value.ToString().Trim())
                    {

                        dataGridView1.CurrentCell = dataGridView1[j, i];
                        dataGridView1.Rows[i].Selected = true;
                        i = i + 1;
                        return;
                    }
                }

               
                textBox4.Text = textBox1.Text;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                int ID = Convert.ToInt32(textBox1.Text);
                List<int> rowsOfInterest = new List<int>();

                Supplier supp = new Supplier();
                supp = DataLayer.SupplierDB.GetSuppliers(ID);

                label3.Text = supp.SupplierId.ToString();
                label4.Text = supp.SupName;
            }
        }
    }
}




















