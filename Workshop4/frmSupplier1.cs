
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



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Text);
            Supplier supp = new Supplier();
            supp = DataLayer.SupplierDB.GetSuppliers(ID);

            label3.Text = supp.SupplierId.ToString();
            label4.Text = supp.SupName;
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

   

        private void update_button_Click_1(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int ID =Convert.ToInt32( dataGridView1.Rows[index].Cells[0].Value.ToString());
           
            textBox4.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            int qq1 = DataLayer.SupplierDB.UpdateSupplier(Convert.ToInt32(textBox4.Text), textBox5.Text);
            if (qq1 > 0)
            {
                MessageBox.Show("Update successful!");
                dataGridView1.DataSource = DataLayer.SupplierDB.GetSuppliers();
            }
            else
            { MessageBox.Show("Update not successful!"); }
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
           
            textBox4.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            label4.BackColor = System.Drawing.Color.LightBlue;
            Supplier supp = new Supplier();
            int id = Convert.ToInt32(textBox4.Text);
            supp = DataLayer.SupplierDB.GetSuppliers(id);
            label3.Text = supp.SupplierId.ToString();
            label4.Text = supp.SupName;
        }


        private void go_home_button_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
        }

        
    }
}




















