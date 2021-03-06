﻿using System;
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
    public partial class frmProductsSuppliers : Form
    {
        public frmProductsSuppliers()
        {
            InitializeComponent();
        }

        private void ProductsSuppliers_Load(object sender, EventArgs e)
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

            dataGridView1.DataSource = DataLayer.Product_SuppliersDB.GetProduct_Suppliers();
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowTemplate.Height = 65;
            //label3.Text = dataGridView1.CurrentCell.Value.ToString();
            dataGridView1.DataSource = DataLayer.Product_SuppliersDB.orderby("ProductSupplierId");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Products_suppliers pro = new Products_suppliers();
            int ID = Convert.ToInt32(textBox1.Text);
            pro = DataLayer.Product_SuppliersDB.GetProduct_Suppliers(ID);
            textBox2.Text = pro.ProductId.ToString();
            textBox3.Text = pro.SupplierId.ToString();



        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();

            textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
