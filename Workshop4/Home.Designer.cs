namespace Workshop4
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PackagesBtn = new System.Windows.Forms.Button();
            this.ProductsBtn = new System.Windows.Forms.Button();
            this.ProdSuppBtn = new System.Windows.Forms.Button();
            this.SuppliersBtn = new System.Windows.Forms.Button();
            this.PackProdSuppBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PackagesBtn
            // 
            this.PackagesBtn.Location = new System.Drawing.Point(306, 159);
            this.PackagesBtn.Name = "PackagesBtn";
            this.PackagesBtn.Size = new System.Drawing.Size(159, 23);
            this.PackagesBtn.TabIndex = 0;
            this.PackagesBtn.Text = "Packages";
            this.PackagesBtn.UseVisualStyleBackColor = true;
            this.PackagesBtn.Click += new System.EventHandler(this.PackagesBtn_Click);
            // 
            // ProductsBtn
            // 
            this.ProductsBtn.Location = new System.Drawing.Point(306, 188);
            this.ProductsBtn.Name = "ProductsBtn";
            this.ProductsBtn.Size = new System.Drawing.Size(159, 23);
            this.ProductsBtn.TabIndex = 1;
            this.ProductsBtn.Text = "Products";
            this.ProductsBtn.UseVisualStyleBackColor = true;
            this.ProductsBtn.Click += new System.EventHandler(this.ProductsBtn_Click);
            // 
            // ProdSuppBtn
            // 
            this.ProdSuppBtn.Location = new System.Drawing.Point(306, 249);
            this.ProdSuppBtn.Name = "ProdSuppBtn";
            this.ProdSuppBtn.Size = new System.Drawing.Size(159, 23);
            this.ProdSuppBtn.TabIndex = 2;
            this.ProdSuppBtn.Text = "Products/Suppliers";
            this.ProdSuppBtn.UseVisualStyleBackColor = true;
            this.ProdSuppBtn.Click += new System.EventHandler(this.ProdSuppBtn_Click);
            // 
            // SuppliersBtn
            // 
            this.SuppliersBtn.Location = new System.Drawing.Point(306, 220);
            this.SuppliersBtn.Name = "SuppliersBtn";
            this.SuppliersBtn.Size = new System.Drawing.Size(159, 23);
            this.SuppliersBtn.TabIndex = 3;
            this.SuppliersBtn.Text = "Suppliers";
            this.SuppliersBtn.UseVisualStyleBackColor = true;
            this.SuppliersBtn.Click += new System.EventHandler(this.SuppliersBtn_Click);
            // 
            // PackProdSuppBtn
            // 
            this.PackProdSuppBtn.Location = new System.Drawing.Point(306, 278);
            this.PackProdSuppBtn.Name = "PackProdSuppBtn";
            this.PackProdSuppBtn.Size = new System.Drawing.Size(159, 23);
            this.PackProdSuppBtn.TabIndex = 4;
            this.PackProdSuppBtn.Text = "Packages/Products/Suppliers";
            this.PackProdSuppBtn.UseVisualStyleBackColor = true;
            this.PackProdSuppBtn.Click += new System.EventHandler(this.PackProdSuppBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "TravelExperts Table Modifier App";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PackProdSuppBtn);
            this.Controls.Add(this.SuppliersBtn);
            this.Controls.Add(this.ProdSuppBtn);
            this.Controls.Add(this.ProductsBtn);
            this.Controls.Add(this.PackagesBtn);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PackagesBtn;
        private System.Windows.Forms.Button ProductsBtn;
        private System.Windows.Forms.Button ProdSuppBtn;
        private System.Windows.Forms.Button SuppliersBtn;
        private System.Windows.Forms.Button PackProdSuppBtn;
        private System.Windows.Forms.Label label1;
    }
}

