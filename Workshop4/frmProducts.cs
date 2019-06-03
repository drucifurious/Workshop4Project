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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.ProductDB.GetProduct();
            dataGridView1.DataSource = DataLayer.ProductDB.orderby("ProductId");
        }

        //display detail of selected record
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.ProductDB.orderby("ProductId");
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                Locate(textBox1.Text);
                textBox5.Text = dataGridView1.CurrentCell.Value.ToString();
                Products prod = new Products();
                int ID = Convert.ToInt32(textBox1.Text);
                prod = DataLayer.ProductDB.GetProducts(ID);
                textBox5.Text = prod.ProductId.ToString();
                textBox6.Text = prod.ProdName;
                textBox7.Text = prod.ProductId.ToString();
                textBox8.Text = prod.ProdName;

                
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataLayer.ProductDB.orderby("ProdName");
            Locate(textBox2.Text);
            int index = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox5.Text = textBox1.Text;
            textBox7.Text = textBox1.Text;

        }


        //let user sort table by product ID and name
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ProdName = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = DataLayer.ProductDB.orderby(ProdName);
        }

        //display detail of selected record
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();

        }

        
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //add new record
        private void Add_button_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("ProductName must be filled");
            }
            else
            {
                //catch error
                try
                {
                    string Prodname = textBox3.Text;
                    int qq1 = DataLayer.ProductDB.AddProduct(textBox3.Text);
                    if (qq1 > 0)
                    {
                        MessageBox.Show("insert successful!");
                        dataGridView1.DataSource = DataLayer.ProductDB.GetProduct();
                    }
                    else
                    {
                        MessageBox.Show("insert not successful!");
                    }
                    dataGridView1.DataSource = DataLayer.ProductDB.orderby("ProductId");
                    Locate(Prodname.ToString());

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

        //method for locating selected record in the table
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

        private void Delete_button_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            string ID1 = dataGridView1.Rows[index].Cells[0].Value.ToString();
            int ID = Convert.ToInt32(ID1);
            DialogResult dr = MessageBox.Show("Do you want to delete ProductID " + ID1 + " ?", "reminder", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Validate();
                try
                {
                    int qq1 = DataLayer.ProductDB.DeleProduct(ID);

                    if (qq1 > 0)
                    {
                        MessageBox.Show("Delete successful!");
                        dataGridView1.DataSource = DataLayer.ProductDB.GetProduct();
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

        private void update_button_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("ProductId must be selected and ProdName must be filled");
            }
            else
            {
                int qq1 = DataLayer.ProductDB.UpdaProduct(Convert.ToInt32(textBox5.Text), textBox6.Text);
                if (qq1 > 0)
                {
                    MessageBox.Show("Update successful!");
                    dataGridView1.DataSource = DataLayer.ProductDB.GetProduct();
                }
                else
                {
                    MessageBox.Show("Update not successful!,Make sure ProductId is correct");
                }

                //display the updated record              
                Products prod = new Products();
                int id = Convert.ToInt32(textBox5.Text);
                prod = DataLayer.ProductDB.GetProducts(id);
                textBox5.Text = prod.ProductId.ToString();
                textBox5.Text = prod.ProdName;
                textBox7.Text = prod.ProductId.ToString();
                textBox8.Text = prod.ProdName;
                //locate cursor to updated record
                dataGridView1.DataSource = DataLayer.ProductDB.orderby("ProductID");

                Locate(textBox5.Text);
            }

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            Locate(textBox5.Text);
        }
    }
    }

