namespace Workshop4
{
    partial class frmPackages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackages));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblSorted = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPackageId = new System.Windows.Forms.TextBox();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.lblPkID = new System.Windows.Forms.Label();
            this.PkName = new System.Windows.Forms.Label();
            this.tblLtPnlPackage = new System.Windows.Forms.TableLayoutPanel();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblPkName = new System.Windows.Forms.Label();
            this.lblPakID = new System.Windows.Forms.Label();
            this.Add_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.txtPkId1 = new System.Windows.Forms.TextBox();
            this.txtPkName1 = new System.Windows.Forms.TextBox();
            this.txtPkId2 = new System.Windows.Forms.TextBox();
            this.txtPkName2 = new System.Windows.Forms.TextBox();
            this.lblPackageID = new System.Windows.Forms.Label();
            this.lblPackageName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tblLtPnlPackage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(175, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Package ID";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblSorted
            // 
            this.lblSorted.AutoSize = true;
            this.lblSorted.Location = new System.Drawing.Point(49, 73);
            this.lblSorted.Name = "lblSorted";
            this.lblSorted.Size = new System.Drawing.Size(79, 13);
            this.lblSorted.TabIndex = 3;
            this.lblSorted.Text = "Data Sorted By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data of Packages Table";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(518, 414);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtPackageId
            // 
            this.txtPackageId.Location = new System.Drawing.Point(921, 76);
            this.txtPackageId.Name = "txtPackageId";
            this.txtPackageId.Size = new System.Drawing.Size(100, 20);
            this.txtPackageId.TabIndex = 6;
            this.txtPackageId.TextChanged += new System.EventHandler(this.txtPackageId_TextChanged);
            // 
            // txtPkgName
            // 
            this.txtPkgName.Location = new System.Drawing.Point(921, 139);
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(100, 20);
            this.txtPkgName.TabIndex = 7;
            this.txtPkgName.TextChanged += new System.EventHandler(this.txtPkgName_TextChanged);
            // 
            // lblPkID
            // 
            this.lblPkID.AutoSize = true;
            this.lblPkID.Location = new System.Drawing.Point(749, 79);
            this.lblPkID.Name = "lblPkID";
            this.lblPkID.Size = new System.Drawing.Size(130, 13);
            this.lblPkID.TabIndex = 8;
            this.lblPkID.Text = "Pelase Enter Package ID ";
            // 
            // PkName
            // 
            this.PkName.AutoSize = true;
            this.PkName.Location = new System.Drawing.Point(752, 146);
            this.PkName.Name = "PkName";
            this.PkName.Size = new System.Drawing.Size(144, 13);
            this.PkName.TabIndex = 9;
            this.PkName.Text = "Please Enter Package Name";
            this.PkName.Click += new System.EventHandler(this.PkName_Click);
            // 
            // tblLtPnlPackage
            // 
            this.tblLtPnlPackage.ColumnCount = 3;
            this.tblLtPnlPackage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.83951F));
            this.tblLtPnlPackage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.16049F));
            this.tblLtPnlPackage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tblLtPnlPackage.Controls.Add(this.lblOperation, 2, 0);
            this.tblLtPnlPackage.Controls.Add(this.lblPkName, 1, 0);
            this.tblLtPnlPackage.Controls.Add(this.lblPakID, 0, 0);
            this.tblLtPnlPackage.Controls.Add(this.Add_button, 2, 2);
            this.tblLtPnlPackage.Controls.Add(this.update_button, 2, 3);
            this.tblLtPnlPackage.Controls.Add(this.Delete_button, 2, 1);
            this.tblLtPnlPackage.Controls.Add(this.txtPkId2, 0, 3);
            this.tblLtPnlPackage.Controls.Add(this.txtPkName2, 1, 3);
            this.tblLtPnlPackage.Controls.Add(this.txtPkId1, 0, 2);
            this.tblLtPnlPackage.Controls.Add(this.txtPkName1, 1, 2);
            this.tblLtPnlPackage.Controls.Add(this.lblPackageID, 0, 1);
            this.tblLtPnlPackage.Controls.Add(this.lblPackageName, 1, 1);
            this.tblLtPnlPackage.Location = new System.Drawing.Point(611, 237);
            this.tblLtPnlPackage.Name = "tblLtPnlPackage";
            this.tblLtPnlPackage.RowCount = 4;
            this.tblLtPnlPackage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.29032F));
            this.tblLtPnlPackage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.70968F));
            this.tblLtPnlPackage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tblLtPnlPackage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tblLtPnlPackage.Size = new System.Drawing.Size(493, 263);
            this.tblLtPnlPackage.TabIndex = 10;
            this.tblLtPnlPackage.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(407, 0);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(82, 40);
            this.lblOperation.TabIndex = 2;
            this.lblOperation.Text = "Operation Option";
            // 
            // lblPkName
            // 
            this.lblPkName.AutoSize = true;
            this.lblPkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPkName.Location = new System.Drawing.Point(136, 0);
            this.lblPkName.Name = "lblPkName";
            this.lblPkName.Size = new System.Drawing.Size(122, 20);
            this.lblPkName.TabIndex = 1;
            this.lblPkName.Text = "Package Name";
            // 
            // lblPakID
            // 
            this.lblPakID.AutoSize = true;
            this.lblPakID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPakID.Location = new System.Drawing.Point(3, 0);
            this.lblPakID.Name = "lblPakID";
            this.lblPakID.Size = new System.Drawing.Size(95, 20);
            this.lblPakID.TabIndex = 0;
            this.lblPakID.Text = "Package ID";
            // 
            // Add_button
            // 
            this.Add_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Add_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Add_button.BackgroundImage")));
            this.Add_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Add_button.Location = new System.Drawing.Point(408, 131);
            this.Add_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(62, 53);
            this.Add_button.TabIndex = 13;
            this.Add_button.UseVisualStyleBackColor = false;
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.update_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("update_button.BackgroundImage")));
            this.update_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.update_button.Location = new System.Drawing.Point(408, 194);
            this.update_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(62, 64);
            this.update_button.TabIndex = 14;
            this.update_button.UseVisualStyleBackColor = false;
            // 
            // Delete_button
            // 
            this.Delete_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Delete_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Delete_button.BackgroundImage")));
            this.Delete_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Delete_button.Location = new System.Drawing.Point(408, 57);
            this.Delete_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(62, 54);
            this.Delete_button.TabIndex = 11;
            this.Delete_button.UseVisualStyleBackColor = false;
            // 
            // txtPkId1
            // 
            this.txtPkId1.Location = new System.Drawing.Point(3, 129);
            this.txtPkId1.Name = "txtPkId1";
            this.txtPkId1.Size = new System.Drawing.Size(100, 20);
            this.txtPkId1.TabIndex = 15;
            this.txtPkId1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // txtPkName1
            // 
            this.txtPkName1.Location = new System.Drawing.Point(136, 129);
            this.txtPkName1.Name = "txtPkName1";
            this.txtPkName1.Size = new System.Drawing.Size(100, 20);
            this.txtPkName1.TabIndex = 16;
            this.txtPkName1.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtPkId2
            // 
            this.txtPkId2.Location = new System.Drawing.Point(3, 192);
            this.txtPkId2.Name = "txtPkId2";
            this.txtPkId2.Size = new System.Drawing.Size(100, 20);
            this.txtPkId2.TabIndex = 17;
            this.txtPkId2.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtPkName2
            // 
            this.txtPkName2.Location = new System.Drawing.Point(136, 192);
            this.txtPkName2.Name = "txtPkName2";
            this.txtPkName2.Size = new System.Drawing.Size(100, 20);
            this.txtPkName2.TabIndex = 18;
            this.txtPkName2.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // lblPackageID
            // 
            this.lblPackageID.AutoSize = true;
            this.lblPackageID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageID.Location = new System.Drawing.Point(3, 52);
            this.lblPackageID.Name = "lblPackageID";
            this.lblPackageID.Size = new System.Drawing.Size(117, 20);
            this.lblPackageID.TabIndex = 19;
            this.lblPackageID.Text = "lbl Package ID";
            // 
            // lblPackageName
            // 
            this.lblPackageName.AutoSize = true;
            this.lblPackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageName.Location = new System.Drawing.Point(136, 52);
            this.lblPackageName.Name = "lblPackageName";
            this.lblPackageName.Size = new System.Drawing.Size(144, 20);
            this.lblPackageName.TabIndex = 20;
            this.lblPackageName.Text = "lbl Package Name";
            // 
            // frmPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(169)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1160, 548);
            this.Controls.Add(this.tblLtPnlPackage);
            this.Controls.Add(this.PkName);
            this.Controls.Add(this.lblPkID);
            this.Controls.Add(this.txtPkgName);
            this.Controls.Add(this.txtPackageId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSorted);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmPackages";
            this.Text = "frmPackages";
            this.Load += new System.EventHandler(this.Packages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tblLtPnlPackage.ResumeLayout(false);
            this.tblLtPnlPackage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblSorted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPackageId;
        private System.Windows.Forms.TextBox txtPkgName;
        private System.Windows.Forms.Label lblPkID;
        private System.Windows.Forms.Label PkName;
        private System.Windows.Forms.TableLayoutPanel tblLtPnlPackage;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Label lblPakID;
        private System.Windows.Forms.Label lblPkName;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.TextBox txtPkId1;
        private System.Windows.Forms.TextBox txtPkName1;
        private System.Windows.Forms.TextBox txtPkId2;
        private System.Windows.Forms.TextBox txtPkName2;
        private System.Windows.Forms.Label lblPackageID;
        private System.Windows.Forms.Label lblPackageName;
    }
}